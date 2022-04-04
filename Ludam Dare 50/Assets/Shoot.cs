using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject projectile;
	public Transform muzzle;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			ShootProjectile();
		}
	}

	void ShootProjectile()
	{
		Instantiate(projectile, muzzle.position, muzzle.rotation);
	}
}
