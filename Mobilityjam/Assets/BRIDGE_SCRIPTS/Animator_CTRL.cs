using UnityEngine;
using System.Collections;

public class Animator_CTRL : MonoBehaviour 
{
	public bool open = false;
	public bool close = false;


	public Animator anim;
	/*
	 * step permet d'avancer dans l'animation du wagon 
	 * 0 = Animation position initial
	 * 0.1 = Animation arrivée à quai
	 * 0.5 = Animation de départ quai
	 




	*/
	[Range(0,0.6f)]
	public float step = 0f;

	public float amt = 0.84f;

	int count = 0;





	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		count = 0;

	
	}
	
	// Update is called once per frame
	void Update () 
	{
        CallTram();
        StartTram();
	
	}

    public void CallTram()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            SetAnimator(0.2f);
        }

        
    }

    public void StartTram()
    {
        if (Input.GetKey(KeyCode.Keypad2))
        {
            SetAnimator(0.6f);
        }


    }

    public void SetAnimator(float step)
	{
		anim.SetFloat("TrainStep",step);
	}

	public void OpenDoors()
	{
		foreach (LeftDoor door in GetComponentsInChildren<LeftDoor>())
		{
			door.SetDoorVector(amt);

			door.transform.position = door.targetValue;
		}

		foreach (RightDoor door in GetComponentsInChildren<RightDoor>())
		{
			door.SetDoorVector(amt);

			door.transform.position = door.targetValue;
		}
	}
	public void CloseDoors()
	{
		foreach (LeftDoor door in GetComponentsInChildren<LeftDoor>())
		{
			door.SetDoorVector(-amt);

			door.transform.position = door.targetValue;
		}
		foreach (RightDoor door in GetComponentsInChildren<RightDoor>())
		{
			door.SetDoorVector(-amt);

			door.transform.position = door.targetValue;
		}
	}
}
