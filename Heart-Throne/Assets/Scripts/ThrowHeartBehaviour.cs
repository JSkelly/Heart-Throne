using UnityEngine;
using System.Collections;

public class ThrowHeartBehaviour : MonoBehaviour {

	public GameObject heart;
	public int force;

	int heartCount;

	// Use this for initialization
	void Start () {
		heartCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && heartCount > 0)
		{
			// Launch heart
			GameObject heartInst = (GameObject)Instantiate(heart, transform.position, transform.rotation);
			heartInst.GetComponent<Rigidbody>().AddForce(transform.forward * force);
			heartInst.GetComponent<HeartBehaviour>().arm = this.gameObject;

			heartCount--;
		}

		// Quits the player when the user hits escape
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}

	public void CaughtHeart()
	{
		heartCount = 1;
	}
}
