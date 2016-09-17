using UnityEngine;
using System.Collections;

public class WheelMovement : MonoBehaviour {

    public Transform _wheelCenter;

    private bool _grabbed = false;
    private float _lastGrabTimeStamp = -999f;
    private float _grabHoverOffTime = 0.1f; //time after which not receiving a signal from the controller is considered as the wheel not being held anymore

    private float _rotationFactor = 20f;

    public void MoveWheel(Transform controller)
    {
        _lastGrabTimeStamp = Time.time;

        if (!_grabbed)
        {
            Debug.Log("ok");
            _grabbed = true;
            StartCoroutine(TurnWheel(controller));
        }

        StartCoroutine(CheckIfGrabbed());
    }

    IEnumerator CheckIfGrabbed()
    {
        _grabbed = true;

        while( (Time.time - _lastGrabTimeStamp) < _grabHoverOffTime)
        {
            yield return null;
        }

        _grabbed = false;
    }

    IEnumerator TurnWheel(Transform controller)
    {
        Vector3 center = transform.InverseTransformPoint(_wheelCenter.position);

        Vector3 startPosG = controller.position; //global startposition controller
        Vector3 startPosL = transform.InverseTransformPoint(startPosG); //local startposition controller
        startPosL = new Vector3(startPosL.x, startPosL.y, 0); //Local startpos projected onto wheel plane

        while (_grabbed) {

            Vector3 controllerCurrPosG = controller.position;
            Vector3 controllerCurrPosL = transform.InverseTransformPoint(controllerCurrPosG); //local startposition controller
            controllerCurrPosL = new Vector3(controllerCurrPosL.x, controllerCurrPosL.y, 0); //Local startpos projected onto wheel plane

            //line between initial point and new point
            Debug.DrawLine(transform.TransformPoint(startPosL), transform.TransformPoint(controllerCurrPosL), Color.red); 
            
            Vector3 startDirL = startPosL - center;
            Debug.DrawLine(transform.TransformPoint(startPosL), transform.TransformPoint(center), Color.red);

            Vector3 currentDirL = controllerCurrPosL - center;
            Debug.DrawLine(transform.TransformPoint(controllerCurrPosL), transform.TransformPoint(center), Color.red);


            float angle = Vector3.Angle(startDirL, currentDirL);

            /*Vector3 axis;

            Quaternion startRot = Quaternion.LookRotation(startDirL);
            Quaternion currRot = Quaternion.LookRotation(currentDirL);

            Quaternion rotationDelta = startRot * Quaternion.Inverse(currRot); //dont worry about this line that's just how you get a drotation delta
            rotationDelta.ToAngleAxis(out angle, out axis); //extracts the angle and axis rotation from the quaternion
            */
            if (angle > 180)
            {
                angle -= 360; //if bigger than 180, rotate the opposite way to do the shortest distance
            }
            float sign = Vector3.Cross(startDirL, currentDirL);

            //this.GetComponent<Rigidbody>().angularVelocity = (Time.fixedDeltaTime * angle * _wheelCenter.forward) * _rotationFactor;
            
            yield return null;
        }
    }
}
