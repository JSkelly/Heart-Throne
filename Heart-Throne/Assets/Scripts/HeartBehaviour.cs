using UnityEngine;
using System.Collections;

public class HeartBehaviour : MonoBehaviour
{
	bool bounced = false;
	public GameObject arm;

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
		Rigidbody rb = this.GetComponent<Rigidbody>();
		switch (other.gameObject.tag)
		{
			case "Floor":
				Debug.Log("Your heart touched the floor!");
				break;
			case "Wall":
				Debug.Log("Your heart touched a wall!");
				rb.velocity = rb.velocity * -3 / 4;
				bounced = true;
				break;
			case "Player":
				if (bounced) {
					Debug.Log("Back to the player!");
					arm.SendMessage("CaughtHeart", SendMessageOptions.DontRequireReceiver);
					Destroy(this);
				}
				break;
			default:
				break;
		}
	}
}