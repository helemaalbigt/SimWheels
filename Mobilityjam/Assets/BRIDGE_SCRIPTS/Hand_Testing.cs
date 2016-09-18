using UnityEngine;
using System.Collections;

public class Hand_Testing : MonoBehaviour 
{
	bool Grabing = true;

	public Mesh Open;
	public Mesh Close;

	public MeshFilter current;

	// Use this for initialization
	void Start () 
	{
		Grabing = false;
		current = GetComponent<MeshFilter>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Grab();
		SetMeshFilter();
	
	}

	void LateUpdate()
	{
		
	}

	void Grab()
	{
		if(Input.GetButtonDown("Jump"))
		{
			Grabing = !Grabing;
		}
	}

	void SetMeshFilter()
	{
		switch (Grabing)
		{
		case true : 
			current.mesh = Close;
			break;
		case false:
			current.mesh = Open;
			break;

		}
	}
}
