using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo2
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class Jugador2 : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxFreno;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxisRaw("Vertical");

        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        float freno = maxFreno * Input.GetAxisRaw("Jump");

            foreach (AxleInfo axleInfo in axleInfos)
            {
                WheelFrictionCurve frenoI = axleInfo.leftWheel.forwardFriction;
                frenoI.stiffness = 1f;
                axleInfo.leftWheel.forwardFriction = frenoI;

                WheelFrictionCurve frenoD = axleInfo.rightWheel.forwardFriction;
                frenoD.stiffness = 1f;
                axleInfo.rightWheel.forwardFriction = frenoD;

                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
                    axleInfo.leftWheel.brakeTorque = freno;
                    axleInfo.rightWheel.brakeTorque = freno;
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }
    }
}