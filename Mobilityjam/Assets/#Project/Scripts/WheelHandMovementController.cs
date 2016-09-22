using UnityEngine;
using System.Collections;
using System;

public abstract class WheelHandMovementController : MonoBehaviour {


    public Transform _targetedHand;
    public Transform _wheelRefDirection;

        


    public float _forceFowardByUnityDistance = 4f;
    public float _forceBackwardByUnityDistance = 4f;
    public float _forceMultiplicator;


    public float _minMoveDistance = 0.05f;
    public float _speedCheckerDelay = 0.2f;

    public WheelVelocity _leftVelocity;
    public WheelVelocity _rightVelocity;

    [Header("Debug (Do touch)")]
    public Vector3 _handGrabStart;

    public Vector3 _lastPositionSpeedRecord;
    public float _handSpeedDistance;

    public int _vibrationsPerMeter = 200;



    void Start() {

        InvokeRepeating("CheckHandSpeed", 0, _speedCheckerDelay);
    }

    void CheckHandSpeed() {

        Vector3 handpos = GetHandPosition();

        Vector3 direction = handpos - _lastPositionSpeedRecord;
        _handSpeedDistance = direction.magnitude;

        _lastPositionSpeedRecord = GetHandPosition();
    }

    // Update is called once per frame
    void Update () {

        if (IshandGrabingDown()) {
            _handGrabStart = GetHandPosition();
        }
        //if (IshandGrabing() ) {

        //    Vector3 currentHandPosition = GetHandPosition();
        //    Vector3 direction = GetHandDirectioncompareToWheelRoot();


        //    float directionOnForwardAxis = direction.z ;

        //    if (IsHandMoving())
        //    {

        //        WheelVelocity wheelSelected =null;
        //        float realForceApply = 0;
        //        Vector3 handRelocatedByWheelRoot = _wheelRefDirection.InverseTransformPoint(_handGrabStart);

        //        wheelSelected = handRelocatedByWheelRoot.x < 0f ? _leftVelocity : _rightVelocity;

        //        realForceApply = _forceMultiplicator* directionOnForwardAxis < 0f ? _forceBackwardByUnityDistance : _forceFowardByUnityDistance;

        //        wheelSelected.SetVelocity(directionOnForwardAxis * realForceApply);

        //    }

        //}

        if (IshandGrabingUp()) {



                Vector3 currentHandPosition = GetHandPosition();
                Vector3 direction = GetHandDirectioncompareToWheelRoot();


                float directionOnForwardAxis = direction.z;

                if (IsHandMoving())
                {

                    WheelVelocity wheelSelected = null;
                    float realForceApply = 0;
                    Vector3 handRelocatedByWheelRoot = _wheelRefDirection.InverseTransformPoint(_handGrabStart);

                    wheelSelected = handRelocatedByWheelRoot.x < 0f ? _leftVelocity : _rightVelocity;

                    realForceApply = _forceMultiplicator * directionOnForwardAxis < 0f ? _forceBackwardByUnityDistance : _forceFowardByUnityDistance;

                    wheelSelected.SetVelocity(directionOnForwardAxis * realForceApply);

                }

            
            _handGrabStart = Vector3.zero;
        }
        
	}

    private Vector3 GetHandDirectioncompareToWheelRoot()
    {
        Vector3 handCurrent= _wheelRefDirection.InverseTransformPoint(GetHandPosition());
        Vector3 handStart= _wheelRefDirection.InverseTransformPoint(_handGrabStart);

        Vector3 directionInSpace = handCurrent - handStart;

        return directionInSpace;



    }

    public Vector3 GetHandPosition(bool relocated = false) {
        if (relocated)
            return _wheelRefDirection.InverseTransformPoint(_targetedHand.position);
        return _targetedHand.position;

    }
    public bool IsHandMoving()
    {
        return _minMoveDistance < _handSpeedDistance;

    }

    public abstract bool IshandGrabing();
    public abstract bool IshandGrabingDown();
    public abstract bool IshandGrabingUp();
}

