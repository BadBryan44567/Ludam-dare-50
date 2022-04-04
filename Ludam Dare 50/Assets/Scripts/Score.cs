using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	int score;
	public TextMeshProUGUI scoreUI;
	public TextMeshProUGUI secondsDelayedUI;
	int timeSinceLevelLoad;

	// Update is called once per frame
	public void CalculateScore()
	{
		timeSinceLevelLoad = Mathf.FloorToInt(Time.timeSinceLevelLoad);
		secondsDelayedUI.text = timeSinceLevelLoad.ToString();
		score = timeSinceLevelLoad * 10;
		scoreUI.text = score.ToString();

	}
}
