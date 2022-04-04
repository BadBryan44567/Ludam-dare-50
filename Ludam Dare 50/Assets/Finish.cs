using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Finish : MonoBehaviour
{
	private static List<Transform> collectedItems = PlayerMovement.droppedItems;
	private static List<Transform> requiredItems = PlayerMovement.requiredMedicines;

	private static List<Transform> submittedItems = new List<Transform>();

	private static bool isfinished;

	bool AreSumittedItemsCorrect()
	{
		if (submittedItems.Count != requiredItems.Count)
		{
			return false;
		}
		for (int i = 0; i < submittedItems.Count; i++)
		{
			if (submittedItems[i] != requiredItems[i])
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
			print("Collision Detected");
			if (collectedItems != null)
			{
				submittedItems.Add(other.transform);
				collectedItems.Remove(other.transform);
				other.gameObject.SetActive(true);
			}

			if (AreSumittedItemsCorrect())
			{
				isfinished = true;
				print("The game is finished");
			}

		}
	}
}
