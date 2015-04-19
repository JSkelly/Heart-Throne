using UnityEngine;
using System.Collections;

public class SpeechLook : MonoBehaviour {
	public GlobalVars globalVars;
	public float speed = 3.0f;
	private Vector3 oldPosition;

	// Use this for initialization
	void Start () {
		oldPosition = transform.position;
		transform.position = new Vector3(0, -100, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (globalVars == null || globalVars.playerController == null)
		{
			return;
		}
		Vector3 diff = globalVars.playerController.position - transform.position + new Vector3(0, 1, 0);

		Quaternion lookat = Quaternion.LookRotation(diff);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookat, Time.deltaTime * speed);
	}

	public void Show()
	{
		Debug.Log("Bubble shown!");
		transform.position = oldPosition;
	}
}
