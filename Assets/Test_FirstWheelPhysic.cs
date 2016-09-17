using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Test_FirstWheelPhysic : MonoBehaviour
{
    public WheelCollider wheelLeft;
    public WheelCollider wheelRight;
    public float maxMotorTorque;
    public float maxSteeringAngle;

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
        float motorLeft = maxMotorTorque * ((Input.GetKey(KeyCode.Keypad4) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad7) ? 1f : 0f)+ (Input.GetKey(KeyCode.Keypad8) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad5) ? -1f : 0f));
        float motorRight = maxMotorTorque * ((Input.GetKey(KeyCode.Keypad6) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad9) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad8) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad5) ? -1f : 0f));

        ApplyForce(motorLeft, wheelLeft);
        ApplyForce(motorRight, wheelRight);

    }

    private void ApplyForce(float motor, WheelCollider wheel)
    {
        //if (axleInfo.steering)
        //{
        //    axleInfo.leftWheel.steerAngle = steering;
        //    axleInfo.rightWheel.steerAngle = steering;
        //}

        wheel.motorTorque = motor;
        wheel.motorTorque = motor;
        ApplyLocalPositionToVisuals(wheel);
        ApplyLocalPositionToVisuals(wheel);
    }
}














//public class Test_FirstWheelPhysic : MonoBehaviour
//{
//    public List<AxleInfo> axleInfos;
//    public float maxMotorTorque;
//    public float maxSteeringAngle;

//    // finds the corresponding visual wheel
//    // correctly applies the transform
//    public void ApplyLocalPositionToVisuals(WheelCollider collider)
//    {
//        if (collider.transform.childCount == 0)
//        {
//            return;
//        }

//        Transform visualWheel = collider.transform.GetChild(0);

//        Vector3 position;
//        Quaternion rotation;
//        collider.GetWorldPose(out position, out rotation);

//        visualWheel.transform.position = position;
//        visualWheel.transform.rotation = rotation;
//    }

//    public void FixedUpdate()
//    {
//        float motor = maxMotorTorque * Input.GetAxis("Vertical");
//        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

//        foreach (AxleInfo axleInfo in axleInfos)
//        {
//            if (axleInfo.steering)
//            {
//                axleInfo.leftWheel.steerAngle = steering;
//                axleInfo.rightWheel.steerAngle = steering;
//            }
//            if (axleInfo.motor)
//            {
//                axleInfo.leftWheel.motorTorque = motor;
//                axleInfo.rightWheel.motorTorque = motor;
//            }
//            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
//            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
//        }
//    }
//    [System.Serializable]
//    public class AxleInfo
//    {
//        public WheelCollider leftWheel;
//        public WheelCollider rightWheel;
//        public bool motor;
//        public bool steering;
//    }
//}
