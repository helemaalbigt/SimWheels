using UnityEngine;
using System.Collections;
using System;

public class DistanceDoneByWheelChair : MonoBehaviour {

    public WheelState _wheelLeftState;
    public WheelState _wheelRightState;

    public float _distanceDoneByLeftWheel;
    public float _distanceDoneByRightWheel;
    // Use this for initialization
    void Start ()
    {
        _wheelLeftState._listenDoWheelMove += AddDistanceDoneLeft;
        _wheelRightState._listenDoWheelMove += AddDistanceDoneRight;

    }

    private void AddDistanceDoneRight(Quaternion lastRotation, Quaternion newRotation, float angleMoved, float distanceMoved, float deltaTimeBetween, float radius)
    {
        _distanceDoneByLeftWheel += distanceMoved;
    }

    private void AddDistanceDoneLeft(Quaternion lastRotation, Quaternion newRotation, float angleMoved, float distanceMoved, float deltaTimeBetween, float radius)
    {
        _distanceDoneByRightWheel += distanceMoved;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
