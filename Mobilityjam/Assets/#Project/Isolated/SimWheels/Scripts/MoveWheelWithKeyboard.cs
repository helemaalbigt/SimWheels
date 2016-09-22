using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class MoveWheelWithKeyboard : MonoBehaviour {


    public KeyCode _moveFoward = KeyCode.Keypad9;
    public KeyCode _moveBackward=KeyCode.Keypad6;
    public Transform _wheelAffected;
    public float _rotationBySecond = 90f;
 
      
	void Update () {

        float direction = 0f;
        if (Input.GetKey(_moveFoward))
            direction += 1f;
        if (Input.GetKey(_moveBackward))
            direction -= 1f;

        _wheelAffected.Rotate(Vector3.right * (_rotationBySecond * Time.deltaTime * direction));


    }
}
