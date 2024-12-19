
using UnityEngine;

public class JumpWalk : MonoBehaviour
{
    private Hiding hiding;
    Vector3 currentJumpVelocity;
    bool isJumping;
    public Transform cam;
    private float speed = 2.0f;

    void Start()
    {
        hiding = gameObject.GetComponent<Hiding>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        Vector3 moveVelocity = Vector3.zero;

        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        
        moveVelocity = forward * vertical + right * horizontal;
        moveVelocity *= speed;

        if (hiding.isHide == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (!isJumping)
                {
                    isJumping = true;
                    currentJumpVelocity = Vector3.up * 3; 
                }
            }

            if (isJumping)
            {
                controller.Move((moveVelocity + currentJumpVelocity) * Time.deltaTime);
                currentJumpVelocity += Physics.gravity * Time.deltaTime;
                
                if (controller.isGrounded)
                {
                    isJumping = false;
                }
            }
            else
            {
                controller.SimpleMove(moveVelocity);
            }
        }
    }
}