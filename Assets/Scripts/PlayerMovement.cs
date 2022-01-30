using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public Camera mPlayerCamera;
    public CharacterController mPlayerController;
    Vector3 mPlayerVelocity;
    bool mbPlayerGrounded;
    public bool mPlayerFixedLocation = false;

    public float speed = 12f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mbPlayerGrounded = mPlayerController.isGrounded;
        
        if (mbPlayerGrounded && mPlayerVelocity.y <0)
        {
            mPlayerVelocity.y = -2;
        }

        if(!mPlayerFixedLocation)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            mPlayerController.Move(move * speed * Time.deltaTime);


            if(Input.GetButtonDown("Jump") && mbPlayerGrounded)
            {
                mPlayerVelocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
            }


            mPlayerVelocity.y -= gravity * Time.deltaTime;

            mPlayerController.Move(mPlayerVelocity * Time.deltaTime);
        }       
    }

    private void FixedUpdate()
    {

    }
}
