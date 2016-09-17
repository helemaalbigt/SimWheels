using UnityEngine;
using System.Collections;
using System;

public class WheelVelocity : MonoBehaviour {

    public float _velocity;
    public float _velocityForce=3f;
    public float _velocityReductionBySec= 2f;
    public Transform _affectedTarget;
    public Vector3 _rotationSetter = new Vector3(360, 0, 0);


    void Start() { TDD(); }

    private void TDD()
    {
        AddVelocity(1000);
    }

    public void AddVelocity(float velocity) {

        _velocity += velocity;
    }
    void Update () {

        if (_velocity != 0f)
            _velocity=  Mathf.MoveTowards(_velocity, 0f, Time.deltaTime * _velocityReductionBySec);
        _affectedTarget.Rotate(_rotationSetter,  Time.deltaTime* _velocity);

    }
}
