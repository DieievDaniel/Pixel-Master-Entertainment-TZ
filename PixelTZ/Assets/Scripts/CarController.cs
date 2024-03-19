using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    protected float horizontalInput, verticalInput;
    protected float currentSteerAngle, currentBrakeForce;
    protected bool isBreaking;

    // Settings
    [SerializeField] protected float motorForce, brakeForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] protected WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] protected WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] protected Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] protected Transform rearLeftWheelTransform, rearRightWheelTransform;

    


    public void AccelerateDown()
    {
        verticalInput = 1f;
        isBreaking = false;
    }
    public void AccelerateUp()
    {
        verticalInput = 0f;
        isBreaking = false;
    }

    public void BrakeDown()
    {
        isBreaking = true;
    }
    public void BrakeUp()
    {
        isBreaking = false;
    }

    public void SteerLeftDown()
    {
        horizontalInput = -1f;
    }
    public void SteerLeftUp()
    {
        horizontalInput = 0f;
    }

    public void SteerRightDown()
    {
        horizontalInput = 1f;
    }
    public void SteerRightUp()
    {
        horizontalInput = 0f;
    }

    public void ReleaseSteeringDown()
    {
        verticalInput = -1f;
    }
    public void ReleaseSteeringUp()
    {
        verticalInput = 0f;
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        ApplyBraking();
        UpdateWheels();
    }

    protected virtual void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = -verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = -verticalInput * motorForce;
        currentBrakeForce = isBreaking ? brakeForce : 0f;
    }

    private void ApplyBraking()
    {
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

   
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}