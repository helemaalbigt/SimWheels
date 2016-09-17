using UnityEngine;
using System.Collections;
using System;

public class PreciseWheelChairMove : MonoBehaviour {

    public Transform _wheelchairRoot;

    [Range(-1f,1f)]
    public float _leftWheel;
    [Range(-1f, 1f)]
    public float _rightWheel;

    


    void Update () {

        float minPower = GetSlowestWheelPower();
	
	}

    private float GetSlowestWheelPower()
    {
        if(Mathf.Abs( _leftWheel ) < Mathf.Abs( _rightWheel ) )
           return _leftWheel;
        return _rightWheel;
    }

    void OnValidate() {
    }
}
