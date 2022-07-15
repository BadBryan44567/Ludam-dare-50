using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
	Rigidbody2D rb;
	public event System.Action OnPlayerDeath;
	public GameObject player;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Threshold")
		{
			if (OnPlayerDeath != null)
			{
				Destroy(player);
				OnPlayerDeath();
			}
		}
	}


}
