using UnityEngine;
using System.Collections;

public class TriggerIndicator : MonoBehaviour 
{
	public float delay = 0.1f;

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Destroy(this.gameObject,delay);
		}
	}


	

}
