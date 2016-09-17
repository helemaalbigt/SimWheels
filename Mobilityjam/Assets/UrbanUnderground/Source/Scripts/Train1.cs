using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Train1 : MonoBehaviour {

	//Handles train animation in demo scene

	public AudioSource mainPASystem;
	public AudioClip trainArriving;
	public AudioClip ambient;
	public AudioClip announcement;
	public AudioClip leaving;

	[HideInInspector]
	public bool trainStopped = false;

	private Light[] lights;
	private Transform startPos;
	private bool playerInside = false;
	AudioSource current;

	Animator anim;

	TrainDoors td;

	void Start () {
		anim = GetComponent<Animator>();
		td = GetComponent<TrainDoors>();
		current = GetComponent<AudioSource>();
		lights = GetComponentsInChildren<Light> ();
		startPos = this.transform;
		foreach (Light light in lights) {
			light.enabled = false;
		}
		foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
			r.enabled = false;
		}
	}

	//TODO uncomment this section to toggle train manually - F key to call it, G key to make it depart the station
	/*
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
			StartCoroutine(LaunchTrain(20f));
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			mainPASystem.volume =0.1f;
			StartCoroutine(leaveStation());
			StartCoroutine(Depart());
		}
	}*/

	public void TrainDepart() {
		if (playerInside) 		mainPASystem.volume = 0.2f;
		StartCoroutine (leaveStation ());
		StartCoroutine (Depart ());
	}

	public void TrainLaunch() {
		StartCoroutine (LaunchTrain (20f));
	}

	IEnumerator LaunchTrain(float s) {
		mainPASystem.Stop();
		mainPASystem.clip = trainArriving;
		mainPASystem.Play();
		yield return new WaitForSeconds(s);
		foreach (Light light in lights) {
			light.enabled = true;
		}
		foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
			r.enabled = true;
		}
		anim.SetTrigger("LaunchTrain");
	}

	void OnTriggerEnter(Collider o) {
		td.doorsMoving = false;
		playerInside = true;
		o.transform.SetParent(this.transform);
		mainPASystem.volume = 0.4f;
		current.volume = 1;
		current.spatialBlend = 0;
	}

	void OnTriggerExit(Collider o) {
		o.transform.SetParent(null);
		playerInside = false;
		current.volume = 0.6f;
		mainPASystem.volume = 0.9f;
		current.spatialBlend = 1;
	}

	public void MakeAnnouncementInsideTrain(){
		if (!playerInside) {
			current.spatialBlend = 1;
		}
		current.clip = announcement;
		current.Play ();
	}

	IEnumerator leaveStation() {
		td.CloseDoors();
		yield return new WaitForSeconds(3f);
		current.Stop();
		current.clip = leaving;
		current.Play();
		/*if (!playerInside) {
			current.spatialBlend = 1;
			current.minDistance = 100;
		} else {
			current.spatialBlend = 0;
		}*/
		td.SecureDoors();
		td.doorsMoving = false;
	}

	IEnumerator Depart() {
		yield return new WaitForSeconds(4f);
		anim.SetTrigger("depart");
		mainPASystem.clip = ambient;
		mainPASystem.Play ();
		if (playerInside) {
			if (Camera.main.GetComponent<CameraShake> () == null) {
				Camera.main.gameObject.AddComponent<CameraShake> ();
				CameraShake cs = Camera.main.GetComponent<CameraShake> ();
				cs.shakeAmount = 0.01f;
				cs.enabled = false;
			}
			FindObjectOfType<CameraShake> ().enabled = true;
			StartCoroutine (RestartLevel ());
		} else {
			StartCoroutine (DisableTrain ());
		}
	}

	IEnumerator RestartLevel() {
		yield return new WaitForSeconds (20f);
		SceneManager.LoadScene ("demo");
	}

	IEnumerator DisableTrain(){
		yield return new WaitForSeconds (30f);
		foreach (Light light in lights) {
			light.enabled = false;
		}
		foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
			r.enabled = false;
		}
		this.transform.position = startPos.position;
		anim.SetTrigger ("reset");
		mainPASystem.volume = 1;
	}

	void OnGUI(){
		if (playerInside) {
			GUIStyle style = new GUIStyle ();
			style.fontSize = 22;
			style.normal.textColor = Color.white;
			Rect rect = new Rect (Screen.width - (Screen.width - 50), Screen.height - 50f, 300, 45);
			GUI.Label (rect, "If you remain inside the train, the level will be reloaded", style);
		}
	}
		
}
