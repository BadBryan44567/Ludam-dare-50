using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
 	float timeBetweenShots;
	bool disabled;

	private void Start()
	{
		timeBetweenShots = 0.1f;
	}

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
		FindObjectOfType<AudioManager>().Play("Gun Shot");
		disabled = true;
		timeBetweenShots = 1f;
		yield return new WaitForSeconds(timeBetweenShots);
		Destroy(instaitatedBullet);
		disabled = false;
	}
}
