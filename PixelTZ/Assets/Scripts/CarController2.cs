using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : CarController
{
    protected override void HandleMotor()
    {
        rearLeftWheelCollider.motorTorque = -verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = -verticalInput * motorForce;
        currentBrakeForce = isBreaking ? brakeForce : 0f;
    }
}
