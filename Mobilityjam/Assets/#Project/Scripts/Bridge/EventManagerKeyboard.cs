using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventManagerKeyboard : MonoBehaviour 
{
	public Animator animatorTarget;



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyUp(KeyCode.R))
		{
			CallTrain();
		}
		else if(Input.GetKeyUp(KeyCode.T))
		{
			DepartTrain();
		}
	
	}

	void Show (bool state)
	{
		foreach (Renderer r  in GetComponentsInChildren<Renderer>()) 
		{
			r.enabled = state;
		}
	}

	void SetTrigger( string _name)
	{
		animatorTarget.SetTrigger(_name);
	}

	void CallTrain()
	{
		Show(true);
		Debug.Log("Train is calling !!");
		SetTrigger("LaunchTrain");

	}

	void DepartTrain()
	{
		Debug.Log("Train start Travel !!");
		SetTrigger("depart");
		StartCoroutine ("Reset");
	}


	IEnumerator Reset()
	{
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("Optimisé");
		
	}

}
