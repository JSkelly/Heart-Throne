using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class AiWander : MonoBehaviour
{
	public Transform[] waypoints;
	private int current = 0;
	public float speed = 3.0f;

	private float timer = 0.15f;
	private float walkBounceAngle = 2.0f;

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

				var npc = transform.Find("NPC0");
				if (npc != null)
				{
					if (timer > 0.5f)
					{
						walkBounceAngle *= -1;
						timer = 0.0f;
					}
					npc.transform.Rotate(new Vector3(0, 1, 0), walkBounceAngle);
				}
			}
		}
		else
		{
			current = 0;
		}
		timer += Time.deltaTime;
	}
}
