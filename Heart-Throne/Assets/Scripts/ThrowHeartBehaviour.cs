using UnityEngine;
using System.Collections;

public class ThrowHeartBehaviour : MonoBehaviour {

	public GameObject heart;
	public int force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			// Launch heart
			GameObject heartInst = (GameObject)Instantiate(heart, transform.position, transform.rotation);
			heartInst.GetComponent<Rigidbody>().AddForce(transform.forward * force);
		}
	}
}
