using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public Transform[] waypoints;
	private int current = 0;
	public float speed = 3.0f;
	public float pauseTime = 2.0f;
	private float timer = 0.0f;
	private bool pause = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	void Move()
	{
		if (current < waypoints.Length)
		{
			Vector3 target = waypoints[current].position;
			Vector3 diff = target - transform.position;
			Vector3 dir = new Vector3(diff.x, 0, diff.z);

			if (dir.magnitude < 1.0f)
			{
				pause = true;
				current++;
			}
			else
			{
				Quaternion lookat = Quaternion.LookRotation(dir);
				transform.rotation = Quaternion.Slerp(transform.rotation, lookat, Time.deltaTime);

				timer += Time.deltaTime;
				if (pause && timer > pauseTime)
				{
					timer = 0.0f;
					pause = false;
				}
				else if(!pause)
				{
					GetComponent<CharacterController>().Move(transform.forward.normalized * speed * Time.deltaTime);
				}
			}
		}
		else
		{
			current = 0;
		}
	}
}
