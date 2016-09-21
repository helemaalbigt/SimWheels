using UnityEngine;
using System.Collections;
using System;

public class WheelVelocity : MonoBehaviour {

    public float _velocity;
    public float _velocityForce=3f;
    public float _maxVelocity=100f;
    public float _velocityReductionBySec= 2f;
    public float _minVelocity = 2f;
    public Transform _affectedTarget;
    public Vector3 _rotationSetter = new Vector3(360, 0, 0);


    void Start() { TDD(); }

    private void TDD()
    {
        //AddVelocity(1000);
    }

    public void AddVelocity(float velocity) {

        _velocity += velocity*_velocityForce;
        _velocity = Mathf.Clamp(_velocity, -_maxVelocity, _maxVelocity);
    }
    void Update () {

        if (Math.Abs(_velocity) >= _minVelocity)
        {
            _velocity -= Math.Sign(_velocity) * 0.8f * Time.deltaTime * _velocityReductionBySec;//Mathf.MoveTowards(_velocity, 0f, Time.deltaTime * _velocityReductionBySec);
        }
        else
        {
            _velocity = 0;
        }
            _affectedTarget.Rotate(_rotationSetter,  Time.deltaTime* _velocity);

    }

    internal void SetVelocity(float velocity)
    {
        velocity = Mathf.Clamp(velocity, -_maxVelocity, _maxVelocity);
        _velocity = velocity;

    }
}