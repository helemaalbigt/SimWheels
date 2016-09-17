using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Respawner : MonoBehaviour {

	//Keeps player on the map using a trigger zone for the demo scene.

	Transform location;

	void Start() {
		location = GameObject.Find ("Respawn").transform;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			other.transform.position = location.position;
		}
	}
}
