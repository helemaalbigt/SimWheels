using UnityEngine;
using System.Collections;

public class PositionPlayer : MonoBehaviour {

    public Transform _headAnchor;
    public Transform _playArea;
    public Transform _player;

    public KeyCode _centerKey = KeyCode.Space;

    // Use this for initialization
    void Start () {
        Invoke("CenterPlayer", 0.5f);
	}

    void Update()
    {
        if (Input.GetKeyDown(_centerKey))
        {
            //TODO: pressing during gameplay doesnt work as expected
            CenterPlayer();
        }
    }
	
	private void CenterPlayer()
    {
        //match headanchor position
        Vector3 dist = _headAnchor.position - _player.position;
        Vector3 distXZ = Vector3.ProjectOnPlane(dist, Vector3.up);//projected on XZ plane (only horizontal)
        _playArea.Translate(distXZ); 

        //match camera rotation
        Vector3 headCurPos = _player.position;//player position pre rotation
        float angle = Quaternion.Angle(_player.rotation, _headAnchor.rotation);
        _playArea.RotateAround(_player.position, Vector3.up, angle);
    }
}
