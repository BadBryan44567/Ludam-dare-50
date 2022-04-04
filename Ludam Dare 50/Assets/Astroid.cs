using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
	public Rigidbody2D rb;
	public float moveBackForce;
	public float moveBackForceIfHitWeakpoint;


	public void MoveBackNormal()
	{
		rb.AddForce(transform.up * moveBackForce);
	}

	public void MoveBackIfHitWeakpoint()
	{
		rb.AddForce(transform.up * moveBackForceIfHitWeakpoint);
	}
}
