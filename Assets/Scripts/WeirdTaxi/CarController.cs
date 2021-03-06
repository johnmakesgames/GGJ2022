using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour

    

{
    private CheckpointSystem CheckpointSystem;

    [SerializeField] WheelCollider FrontRight;
    [SerializeField] WheelCollider FrontLeft;
    [SerializeField] WheelCollider RearRight;
    [SerializeField] WheelCollider RearLeft;

    [SerializeField] Transform FrontRightTransform;
    [SerializeField] Transform FrontLeftTransform;
    [SerializeField] Transform RearRightTransform;
    [SerializeField] Transform RearLeftTransform;

    public float accel = 500f;
    public float brakeForce = 300f;
    public float maxTurn = 25f;

    private float currentAccel = 0f;
    private float currentBrake = 0f;
    private float currentTurn = 0f;

    private void FixedUpdate()
    {
        //acceleration and reverse
        currentAccel = accel * Input.GetAxis("Vertical");


        //apply braking
        if (Input.GetKey("space"))
        {
            currentBrake = brakeForce;
        }
        else
            currentBrake = 0f;

        //apply acceleration
        FrontRight.motorTorque = currentAccel;
        FrontLeft.motorTorque = currentAccel;
        RearRight.motorTorque = currentAccel;
        RearLeft.motorTorque = currentAccel;


        //send braking force to the wheels
        FrontRight.brakeTorque = currentBrake;
        FrontLeft.brakeTorque = currentBrake;
        RearRight.brakeTorque = currentBrake;
        RearLeft.brakeTorque = currentBrake;

        //turning
        currentTurn = maxTurn * Input.GetAxis("Horizontal");
        FrontLeft.steerAngle = currentTurn;
        FrontRight.steerAngle = currentTurn;

        //update wheel meshes
        updatewheel(FrontLeft, FrontLeftTransform);
        updatewheel(FrontRight, FrontRightTransform);
        updatewheel(RearLeft, RearLeftTransform);
        updatewheel(RearRight, RearRightTransform);

        //flip the car
        if (Input.GetKey("e"))
        {
            transform.rotation = Quaternion.identity;
        }

        //start the checkpoint challenge
        if (Input.GetKey("q"))
        {
            //start chanllenge
            
        }
    }

    void updatewheel(WheelCollider col, Transform trans)
    {
        //get wheel colider posistion
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        //set wheel transform
        trans.position = position;
        trans.rotation = rotation;
    }

    
}
