using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float speed;

	private void Update()
	{
		transform.Translate(transform.right * speed * Time.deltaTime);
	}
}
