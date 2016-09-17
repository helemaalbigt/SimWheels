using UnityEngine;
using System.Collections;

public class WheelChairSquareForce : MonoBehaviour {

    public Rigidbody _rigBody;
    public Transform _fowardRight;
    public Transform _fowardLeft;
    public Transform _backRight;
    public Transform _backLeft;
    public Transform _topCenter;

    public float _force=10;

    void Start () {
	
	}
	

	void Update () {

        float motorLeft = _force * ((Input.GetKey(KeyCode.Keypad4) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad7) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad8) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad5) ? -1f : 0f));
        float motorRight = _force * ((Input.GetKey(KeyCode.Keypad6) ? -1f : 0f) + (Input.GetKey(KeyCode.Keypad9) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad8) ? 1f : 0f) + (Input.GetKey(KeyCode.Keypad5) ? -1f : 0f));
        Transform tranUseForMotorLeft = motorLeft < 0f ? _backLeft : _fowardLeft;
        Transform tranUseForMotorRight = motorRight < 0f ? _backRight : _fowardRight;

        if(motorLeft!=0f)
            _rigBody.AddForceAtPosition(tranUseForMotorLeft.forward * Mathf.Abs(motorLeft), tranUseForMotorLeft.position, ForceMode.Acceleration);

        if (motorRight != 0f)
            _rigBody.AddForceAtPosition(tranUseForMotorRight.forward * Mathf.Abs(motorRight), tranUseForMotorRight.position, ForceMode.Acceleration);

        //_rigBody.AddForceAtPosition(_topCenter.forward * _force/4f, _topCenter.position, ForceMode.Force);
    }
}
