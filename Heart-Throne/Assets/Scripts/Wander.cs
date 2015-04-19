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

			if (dir.magnitude < 2.0f)
			{
				current++;
			}
			else
			{
				Quaternion lookat = Quaternion.LookRotation(dir);
				transform.rotation = Quaternion.Slerp(transform.rotation, lookat, Time.deltaTime);

				float actualSpeed = Mathf.Abs(Quaternion.Angle(transform.rotation, lookat)) < 45.0f ? speed : speed / 5;
				GetComponent<CharacterController>().Move(transform.forward.normalized * actualSpeed * Time.deltaTime);
			}
		}
		else
		{
			current = 0;
		}
	}
}
