using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 45;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;
	float time = 1.0f;

	void Awake()
	{
		controller = GetComponent<CharacterController>();

		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}

	void Update()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);

		time -= Time.deltaTime;
		if (time < 0.0f)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
			{
				if (hit.transform != this.transform)
				{
					Debug.Log("hit!");
					Debug.DrawLine(transform.position, hit.point, Color.white);
					NewHeadingRoutine(180);
				}
			}

			time = 1.0f;
		}
	}

	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading()
	{
		while (true)
		{
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine(float maxHeading = 0.0f)
	{
		if (maxHeading == 0.0f)
		{
			maxHeading = maxHeadingChange;
		}
		var floor = Mathf.Clamp(heading - maxHeading, 0, 360);
		var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}
}
