using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
	public float followSpeed;
	public float waitTime = 0.3f;
	public float turnSpeed = 90;

	public Transform pathHolder;

	private void Start()
	{
		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++)
		{
			waypoints[i] = pathHolder.GetChild(i).position;
			waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
		}

		StartCoroutine(FollowPath(waypoints));
	}


	IEnumerator FollowPath(Vector3[] waypoints)
	{
		transform.position = waypoints[0];

		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints[targetWaypointIndex];
		transform.LookAt(targetWaypoint);
		while (true)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, followSpeed * Time.deltaTime);
			if (transform.position == targetWaypoint)
			{
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				targetWaypoint = waypoints[targetWaypointIndex];
				yield return new WaitForSeconds(waitTime);
				yield return StartCoroutine(RotateGuard(targetWaypoint));
			}
			yield return null;
		}
	}

	IEnumerator RotateGuard(Vector3 target)
	{
		Vector3 direction = (target - transform.position).normalized;
		float targetAngle = 90 - Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

		while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
		{
			float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = transform.up * angle;
			yield return null;
		}
	}

	private void OnDrawGizmos()
	{
		Vector3 perviousPosition = pathHolder.GetChild(pathHolder.childCount - 1).position; ;

		foreach (Transform waypoint in pathHolder)
		{
			Gizmos.DrawSphere(waypoint.position, .3f);
			Gizmos.DrawLine(perviousPosition, waypoint.position);
			perviousPosition = waypoint.position;
		}
	}

}
