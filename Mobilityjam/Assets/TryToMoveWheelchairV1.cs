using UnityEngine;
using System.Collections;
using System;

public class TryToMoveWheelchairV1 : MonoBehaviour
{

    public Transform _wheelchairRoot;
    public WheelState _wheelLeftState;
    public WheelState _wheelRightState;
    
    void Update()
    {

        float moveFowardOf=0;
        float rotateHorizontal = 0f;
        GetDistanceMovedByTheChair(_wheelLeftState, _wheelRightState, out moveFowardOf, out rotateHorizontal);



        print("Angle from: " + rotateHorizontal);
        //???
        _wheelchairRoot.rotation = Quaternion.Euler(new Vector3(0, -rotateHorizontal , 0)) * _wheelchairRoot.rotation;

        print("Move from: " + moveFowardOf);
        _wheelchairRoot.position += _wheelchairRoot.forward * moveFowardOf ;

    }

    private void GetDistanceMovedByTheChair(WheelState _wheelLeftState, WheelState _wheelRightState, out float realDistanceMoved, out float  horizontalRotationAngle)
    {
        float distanceBetween = WheelState.GetDistanceBetweenGroundRoot(_wheelLeftState, _wheelRightState);
        horizontalRotationAngle = 0f;
        realDistanceMoved = 0f;

        float distanceLeftWheel = _wheelLeftState.GetDistanceWithDirection();
        float distanceRightWheel = _wheelRightState.GetDistanceWithDirection();/////////
       print((distanceLeftWheel*1000f)+ " <D> " + (distanceRightWheel*1000f));

        realDistanceMoved = (distanceLeftWheel + distanceRightWheel) / 2f ;


        //////////////////////////

        float angle = 0;
            angle =( (distanceRightWheel - distanceLeftWheel) / distanceBetween) * Mathf.Rad2Deg;
        horizontalRotationAngle = angle;


    }

   
}