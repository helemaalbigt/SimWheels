using UnityEngine;
using System.Collections;

public class LinkableObject : MonoBehaviour {

    public Transform _rootAffected;

	// Use this for initialization
	public void LinkTo (Transform _targetToLinkTo) {
        if(_rootAffected)
        _rootAffected.parent = _targetToLinkTo;
    }
	
	// Update is called once per frame
	public void Unlink () {
        LinkTo(null);
	
	}
}
