using UnityEngine;
using System.Collections;

public class SpeechLook : MonoBehaviour {
	public Transform target;
	public float speed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diff = target.position - transform.position;

		Quaternion lookat = Quaternion.LookRotation(diff);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookat, Time.deltaTime * speed);
	}
}
