using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackingController : MonoBehaviour
{
    private Transform PositionToReturnControllerTo;
    private Camera PlayerCamera;
    [SerializeField] private Camera ControllerCamera;

    // Start is called before the first frame update
    void Start()
    {
        ControllerCamera.enabled = false;
        enabled = false;
    }

    void MoveToThisController()
    {
        PlayerMovement movementComponent = GetComponent<PlayerMovement>();
        MouseLook mouseComponent = GetComponentInChildren<MouseLook>();
        Camera camera = GetComponentInChildren<Camera>();
        if (movementComponent && mouseComponent && camera)
        {
            PlayerCamera = camera;
            PlayerCamera.enabled = false;
            ControllerCamera.enabled = true;
            PositionToReturnControllerTo = gameObject.transform;

            mouseComponent.enabled = false;
            movementComponent.enabled = false;
            this.enabled = true;
        }
    }

    void MoveToFPPMovement()
    {
        PlayerMovement movementComponent = GetComponent<PlayerMovement>();
        MouseLook mouseComponent = GetComponentInChildren<MouseLook>();
        Camera camera = GetComponentInChildren<Camera>();
        if (movementComponent && mouseComponent && camera)
        {
            PositionToReturnControllerTo = null;
            PlayerCamera.enabled = true;
            ControllerCamera.enabled = false;
            PlayerCamera = null;

            mouseComponent.enabled = true;
            movementComponent.enabled = true;
            this.enabled = false;
        }
    }

    public void SwapMovements()
    {
        if(enabled)
        {
            MoveToFPPMovement();
        }
        else
        {
            MoveToThisController();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
             MoveToFPPMovement();
        }

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += Time.deltaTime * 120.0f;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
