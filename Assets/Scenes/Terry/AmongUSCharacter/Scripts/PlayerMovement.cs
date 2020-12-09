using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 0.4f;
    private float gravityValue = -9.81f;
    public bool canMove = true;
    public bool rotateAroundPlayer = true;
    public bool lookAtPlayer = false;
    public float rotationSpeed = 5.0f;
    public float yFallLimit;
    public Transform playerTransform;

    private Vector3 lastPosition;
    private Vector3 positionBeforeJump;

    public static PlayerMovement instance;

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (canMove == true)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * move;
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (transform.position.y < yFallLimit && !groundedPlayer)
            {
                transform.position = positionBeforeJump;
                GameManager.Instance.tabletNumber--;
                GameManager.Instance.TakeDamage();
            }

            if ((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && canMove == true)
                AudioManager.Instance.PlayAudio("Running");

            if ((!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && AudioManager.Instance.sounds[3].audioSource.isPlaying)
                || canMove == false)
                AudioManager.Instance.StopAudio("Running");

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            if (Input.GetKey(KeyCode.Space) && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                positionBeforeJump = transform.position;
                animator.SetTrigger("jump");
                AudioManager.Instance.StopAudio("Running");
                AudioManager.Instance.PlayAudio("Jump");
            }                
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float speed = Vector3.Distance(lastPosition, transform.position) / Time.deltaTime;
        animator.SetFloat("speed", speed);
        lastPosition = this.transform.position;
    }

    public void FixedUpdate()
    {
        
    }
}
