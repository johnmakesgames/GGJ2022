using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackingPlayerController : MonoBehaviour
{
    [SerializeField] private GameObject UnpackingRootObject;
    [SerializeField] private GameObject ItemSpawnerBox;
    private Transform PositionToReturnControllerTo;
    private Camera PlayerCamera;
    [SerializeField] private Camera ControllerCamera;
    private float cameraSpinSpeed = 10.0f;
    private float cameraAngleOnCircle = 1.0f;
    public float heightAngle = 100.0f * (2.0f / 3.0f);
    public float revolveRadius = 3.9f;
    [SerializeField] private List<Transform> roomCenters;
    private int currentRoom = 0;

    private bool isHoldingObject = false;
    private GameObject heldObject = null;

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
        PlayerInteraction interaction = GetComponent<PlayerInteraction>();
        Camera camera = GetComponentInChildren<Camera>();
        if (movementComponent && mouseComponent && camera)
        {
            PlayerCamera = camera;
            PlayerCamera.enabled = false;
            ControllerCamera.enabled = true;
            PositionToReturnControllerTo = gameObject.transform;
            UnpackingRootObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;

            interaction.enabled = false;
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
        PlayerInteraction interaction = GetComponent<PlayerInteraction>();
        if (movementComponent && mouseComponent && camera)
        {
            PositionToReturnControllerTo = null;
            PlayerCamera.enabled = true;
            ControllerCamera.enabled = false;
            PlayerCamera = null;
            UnpackingRootObject.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            interaction.enabled = true;
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
        CameraControlUpdate();

        if(isHoldingObject && heldObject != null)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                heldObject.transform.Rotate(Vector3.up, 90.0f, Space.Self);
            }

            Ray ray = ControllerCamera.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("HeldFurnitureItem");
            if(Physics.Raycast(ray, out RaycastHit hit, 100.0f, ~mask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);

                Ray rayDown = new Ray(hit.point, Vector3.down);

                if (Physics.Raycast(ray, out RaycastHit downwardHit, 10.0f, ~mask))
                {
                    Debug.DrawLine(hit.point, downwardHit.point, Color.blue);
                    heldObject.transform.position = downwardHit.point;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
             MoveToFPPMovement();
        }
    }

    void CameraControlUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        if(vertical > 0 && currentRoom + 1 < roomCenters.Count)
        {
            currentRoom++;
        }
        else if (vertical < 0 && currentRoom - 1 > 0)
        {
            currentRoom--;
        }

        float horizontal = Input.GetAxis("Horizontal") * cameraSpinSpeed;

        if (horizontal != 0.0f)
        {
            cameraAngleOnCircle += horizontal;

            if (cameraAngleOnCircle > 360.0f)
                cameraAngleOnCircle %= 360.0f;
            else if (cameraAngleOnCircle < 0.0f)
                cameraAngleOnCircle %= 360.0f;
        }

        float camAngleRadians = Mathf.Deg2Rad * cameraAngleOnCircle;
        float heightAngleRadians = Mathf.Deg2Rad * heightAngle;

        ControllerCamera.transform.position = new Vector3(
            roomCenters[currentRoom].position.x + (revolveRadius * Mathf.Cos(camAngleRadians) * Mathf.Sin(heightAngleRadians)),
            roomCenters[currentRoom].position.y + (revolveRadius * Mathf.Cos(heightAngleRadians)),
            roomCenters[currentRoom].position.z + (revolveRadius * Mathf.Sin(camAngleRadians) * Mathf.Sin(heightAngleRadians)));

        ControllerCamera.transform.LookAt(roomCenters[currentRoom]);
        
        if(Input.GetMouseButtonDown(0))
        {
            float rayDistance = 200.0f;
            Ray ray = ControllerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hitResults = Physics.RaycastAll(ray, rayDistance);
            GameObject targetObject = null;

            if (hitResults.Length != 0)
            {
                foreach(RaycastHit hitResult in hitResults)
                {
                    targetObject = hitResult.collider.gameObject;

                    if (targetObject.transform.parent)
                    {
                        if (targetObject.transform.parent.tag == "UnpackingFurniture")
                        {
                            if (targetObject.transform.parent.name == "Spawner")
                            {
                                ItemSpawnerBox.GetComponent<UnpackingFurnitureSpawner>().Spawn();
                            }
                            else
                            {
                                heldObject = targetObject.transform.parent.gameObject;

                                Transform[] ts = heldObject.GetComponentsInChildren<Transform>();
                                foreach (Transform t in ts)
                                {
                                    t.gameObject.layer = LayerMask.NameToLayer("HeldFurnitureItem");
                                }

                                heldObject.GetComponentInChildren<Collider>().isTrigger = true;
                                heldObject.layer = LayerMask.NameToLayer("HeldFurnitureItem");
                                isHoldingObject = true;
                            }
                        }
                    }
                }               
            }
        }

        if(Input.GetMouseButtonUp(0) && isHoldingObject)
        {
            Transform[] ts = heldObject.GetComponentsInChildren<Transform>();
            foreach (Transform t in ts)
            {
                t.gameObject.layer = LayerMask.NameToLayer("Default");
            }

            heldObject.GetComponentInChildren<Collider>().isTrigger = false;
            heldObject.layer = LayerMask.NameToLayer("Default");
            heldObject = null;
            isHoldingObject = false;
        }
    }
}
