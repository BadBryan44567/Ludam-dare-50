using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	public float speed = 12f;

	Vector3 velocity;
	public float gravity = -9.81f;
	public Transform groundCheck;
	public float groundDistnace;
	public LayerMask groundMask;
	bool isGrounded;

	public float jumpHeight = 3;

	List<Transform> collectedItems = new List<Transform>();
	public List<Transform> requiredMedicines = new List<Transform>();
	bool isfinished;

	// Update is called once per frame
	void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistnace, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		float xInput = Input.GetAxis("Horizontal");
		float zInput = Input.GetAxis("Vertical");

		Vector3 move = transform.right * xInput + transform.forward * zInput;
		controller.Move(move * speed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

	}

	bool isTaskFinished()
	{
		if (collectedItems.Count != requiredMedicines.Count)
		{
			return false;
		}
		for (int i = 0; i < collectedItems.Count; i++)
		{
			if (collectedItems[i] != requiredMedicines[i])
			{
				return false;
			}
		}
		return true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup Item")
		{
			collectedItems.Add(other.gameObject.transform);
			other.gameObject.SetActive(false);
		}

		if (other.tag == "Finish")
		{
			if (isTaskFinished())
			{
				print("Finish");
			}
		}
	}
}

