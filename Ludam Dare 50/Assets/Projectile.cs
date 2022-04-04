using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;
	public GameObject astroid;

	private void Start()
	{
		rb.velocity = transform.up * speed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		print(other.gameObject.name);

		if (other.gameObject.tag != "Weak Point")
		{
			astroid.GetComponent<Rigidbody2D>().AddForce(transform.up * 200);
			print(other.gameObject.name);
		}
		if (astroid != null && other.gameObject.tag == "Weak Point")
		{
			astroid.GetComponent<Rigidbody2D>().AddForce(transform.up * 2000);
			print(other.gameObject.name);
		}

		Destroy(gameObject);
	}
}
