using UnityEngine;
using System.Collections;
using System;

public class TryToMoveWheelchairV1 : MonoBehaviour
{

    public Transform _wheelchairRoot;
    public WheelState _wheelLeftState;
    public WheelState _wheelRightState;
    
    void LateUpdate()
    {

        float moveFowardOf=0;
        float rotateHorizontal = 0f;
        GetDistanceMovedByTheChair(_wheelLeftState, _wheelRightState, out moveFowardOf, out rotateHorizontal);



        if (Time.timeSinceLevelLoad > 0.5f)
        {
            //???
            _wheelchairRoot.rotation = Quaternion.Euler(new Vector3(0, -rotateHorizontal, 0)) * _wheelchairRoot.rotation;

            if (moveFowardOf != 0f)
                _wheelchairRoot.position += _wheelchairRoot.forward * moveFowardOf;
        }
    }

    private void GetDistanceMovedByTheChair(WheelState _wheelLeftState, WheelState _wheelRightState, out float realDistanceMoved, out float  horizontalRotationAngle)
    {
        float distanceBetween = WheelState.GetDistanceBetweenGroundRoot(_wheelLeftState, _wheelRightState);
        horizontalRotationAngle = 0f;
        realDistanceMoved = 0f;

        float distanceLeftWheel = _wheelLeftState.GetDistanceWithDirection();
        float distanceRightWheel = _wheelRightState.GetDistanceWithDirection();/////////
      
        realDistanceMoved = (distanceLeftWheel + distanceRightWheel) / 2f ;


        //////////////////////////

        float angle = 0;
            angle =( (distanceRightWheel - distanceLeftWheel) / distanceBetween) * Mathf.Rad2Deg;
       // Debug.Log("Angle: "+angle);
        horizontalRotationAngle = angle;


    }

   
}