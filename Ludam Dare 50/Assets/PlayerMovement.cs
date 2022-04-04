using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	float timeRemaining = 19;
	bool timerIsRunning = false;

	public Text timerText;

	private void Start()
	{
		timerIsRunning = true;
	}

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

		if (timerIsRunning)
		{
			if (timeRemaining > 0)
			{
				timeRemaining -= Time.deltaTime;
				DisplayTime(timeRemaining);
			}
			else
			{
				if (isfinished != true)
				{
					print("Time has run out!");
				}
				timeRemaining = 0;
				timerIsRunning = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			for (int i = 0; i < collectedItems.Count;)
			{
				Vector3 previousPosition = collectedItems[i].position;
				collectedItems[i].position = transform.position + previousPosition / 2;
				collectedItems[i].gameObject.SetActive(true);
				collectedItems.Remove(collectedItems[i]);
				break;
			}
		}

	}

	bool broughtCorrectMedicines()
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
			if (broughtCorrectMedicines())
			{
				isfinished = true;
			}
		}
	}

	public void DisplayTime(float timeToDisplay)
	{
		timeToDisplay += 1;

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}

