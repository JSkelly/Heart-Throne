using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class AiLook: MonoBehaviour
{
	public GlobalVars globalVars;

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
		if (globalVars == null || globalVars.playerController == null)
		{
			return;
		}
		Vector3 diff = globalVars.playerController.position - transform.position;
		Vector3 dir = new Vector3(diff.x, 0, diff.z);

		Quaternion lookat = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookat, Time.deltaTime);
	}
}
