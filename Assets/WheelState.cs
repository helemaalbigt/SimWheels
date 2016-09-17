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

    internal static float GetDistanceBetweenGroundRoot(WheelState _wheelLeftState, WheelState _wheelRightState)
    {
        return Vector3.Distance(_wheelLeftState._wheelGroundRoot.position, _wheelRightState._wheelGroundRoot.position);
    }

    void LateUpdate ()
    {
        _distanceByFrame = 0;
        _angleByFrame = 0;
        if (_listenDoWheelMove != null)
        {
            
            float direction = GetDirectionOfWheelRotating(GetPreviousRotation(), GetCurrentRotation());
           
            float angleMoved = direction * GetAngleOf(GetPreviousRotation(), GetCurrentRotation());

            float distanceMoved = 0f;
            if (angleMoved != 0f)
                  distanceMoved = GetDistanceMoved(angleMoved, GetWheelRadius());

            _listenDoWheelMove(GetPreviousRotation(), GetCurrentRotation(),angleMoved, distanceMoved,  Time.deltaTime, GetWheelRadius()  );
        }

        _lastLocalRotation = GetCurrentRotation();
    }

    public float GetDirectionOfWheelRotating(Quaternion previewRotation, Quaternion currentRotation)
    {

        Vector3 preview = (Quaternion.Inverse(currentRotation) * previewRotation) * Vector3.forward;
        Vector3 current = currentRotation * Vector3.forward;
 
        Debug.DrawLine(Vector3.zero, preview, Color.cyan, Time.deltaTime);
        Debug.DrawLine(Vector3.zero, current, Color.green, Time.deltaTime);

        //print( "iiiii: "+ preview.y);

        if (preview.y>0f)
            return 1f;
        return -1f;

        //if (recenterRotAsPoint.x < 0f) return -1f;
        //if (recenterRotAsPoint.x > 0f) return 1f;
        //return 0f;

    }

    public float GetDistanceMoved(Quaternion rotationOne, Quaternion rotationTwo, float radius)
    {
        return GetDistanceMoved(Quaternion.Angle(rotationOne, rotationTwo),radius);
    }
    public float GetDistanceMoved(float angle, float radius)
    {
        float ratio = angle / 360f;
        float circonference = 2f * Mathf.PI * radius;
        return circonference * ratio;
    }

    public float GetAngleOf(Quaternion rotationOne, Quaternion rotationTwo)
    {

        return Quaternion.Angle(rotationOne, rotationTwo);
    }

    public Quaternion GetCurrentRotation() { return _wheelCenterRoot.localRotation; }
    public Quaternion GetPreviousRotation() { return _lastLocalRotation; }

    public float GetWheelRadius() { return Vector3.Distance(_wheelCenterRoot.position, _wheelGroundRoot.position); }

    public float GetDistanceWithDirection() {
      float distance =  GetDistanceMoved(GetPreviousRotation(), GetCurrentRotation(), GetWheelRadius());
        distance *= GetDirectionOfWheelRotating(GetPreviousRotation(), GetCurrentRotation());
        return distance;
    }
}
