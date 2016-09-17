using UnityEngine;
using System.Collections;
using System;

public class WheelState : MonoBehaviour {

    public Transform _wheelCenterRoot;
    public Transform _wheelGroundRoot;
    public Quaternion _lastLocalRotation;

    public delegate void ListenToWheelRotation( Quaternion lastRotation, Quaternion newRotation , float angleMoved, float distanceMoved , float deltaTimeBetween, float radius );
    public ListenToWheelRotation _listenDoWheelMove ;


    [Header("Debug (Do not touch)")]
    [Range(-1f,1f)]
    public float _distanceByFrame;
    [Range(-180f, 180f)]
    public float _angleByFrame;

    void Start() {

        _listenDoWheelMove += SetDebugValue;
    }

    private void SetDebugValue(Quaternion lastRotation, Quaternion newRotation, float angleMoved,float distanceMoved, float deltaTimeBetween, float radius)
    {
        _angleByFrame = angleMoved;
        _distanceByFrame = distanceMoved;
    }

    void LateUpdate () {

        if (_listenDoWheelMove != null)
        {
            float angleMoved = GetAngleOf(GetPreviousRotation(), GetCurrentRotation());
            float distanceMoved = GetDistanceMoved(angleMoved, GetWheelRadius());
            _listenDoWheelMove(GetPreviousRotation(), GetCurrentRotation(),angleMoved, Time.deltaTime, GetWheelRadius() , distanceMoved );
        }

        _lastLocalRotation = GetCurrentRotation();
    }



    private float GetDistanceMoved(Quaternion rotationOne, Quaternion rotationTwo, float radius)
    {
        return GetDistanceMoved(Quaternion.Angle(rotationOne, rotationTwo),radius);
    }
    private float GetDistanceMoved(float angle, float radius)
    {
        float ratio = angle / 360f;
        float circonference = 2f * Mathf.PI * radius;

        return circonference * ratio;
    }

    private float GetAngleOf(Quaternion rotationOne, Quaternion rotationTwo)
    {
        return Quaternion.Angle(rotationOne, rotationTwo);
    }

    public Quaternion GetCurrentRotation() { return _wheelCenterRoot.localRotation; }
    public Quaternion GetPreviousRotation() { return _lastLocalRotation; }

    public float GetWheelRadius() { return Vector3.Distance(_wheelCenterRoot.position, _wheelGroundRoot.position); }

}
