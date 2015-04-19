using UnityEngine;
using System.Collections;

public class HeartBehaviour : MonoBehaviour
{
	float delay;
	public GameObject arm;

	// Use this for initialization
	void Start()
	{
		delay = 0.5f;
	}

	// Update is called once per frame
	void Update()
	{
		delay -= Time.deltaTime;
	}

	public void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	void OnTriggerEnter(Collider other)
	{
		Rigidbody rb = this.GetComponent<Rigidbody>();
		switch (other.gameObject.tag)
		{
			case "Floor":
				Debug.Log("Your heart touched the floor!");
				this.gameObject.SendMessage("ReloadLevel");
				break;
			case "Wall":
				Debug.Log("Your heart touched a wall!");
				rb.velocity = rb.velocity * -3 / 4;
				break;
			case "Player":
				if (delay <= 0.0f) {
					Debug.Log("Back to the player!");
					arm.SendMessage("CaughtHeart", SendMessageOptions.DontRequireReceiver);
					this.gameObject.GetComponent<MeshRenderer>().enabled = false;
					Destroy(this);
				}
				break;
			case "Bounce":
				rb.velocity = new Vector3(0, 5, 0);
				break;
			case "StreetLight":
				rb.velocity = new Vector3(10, 2, 0);
				break;
			default:
				break;
		}
	}
}