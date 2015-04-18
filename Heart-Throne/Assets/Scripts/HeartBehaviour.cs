using UnityEngine;
using System.Collections;

public class HeartBehaviour : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		{
			if (other.gameObject.tag == "Floor")
			{
				Debug.Log("Your heart touched the floor!");
			}
		}
	}
}