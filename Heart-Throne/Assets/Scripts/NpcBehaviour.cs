using UnityEngine;
using System.Collections;

public class NpcBehaviour : MonoBehaviour {
	public GameObject bubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowBubble()
	{
		if (bubble != null)
		{
			bubble.SendMessage("Show");
			GetComponent<AudioSource>().Play();
		}
	}
}
