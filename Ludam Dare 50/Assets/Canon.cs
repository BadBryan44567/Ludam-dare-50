using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float timeBetweenShots;
	bool disabled;
	// Update is called once per frame
	void Update()
	{
		if (!disabled)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				StartCoroutine(Shoot());
			}
		}
	}

	IEnumerator Shoot()
	{
		GameObject instaitatedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
		disabled = true;
		yield return new WaitForSeconds(timeBetweenShots);
		Destroy(instaitatedBullet);
		disabled = false;
	}
}
