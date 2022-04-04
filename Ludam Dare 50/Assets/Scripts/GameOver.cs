using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public GameObject gameOverScreen;
	public TextMeshProUGUI secondsDelayedUI;
	bool isGameOver;

	private void Start()
	{
		FindObjectOfType<Astroid>().OnPlayerDeath += OnGameOver;
	}

	private void Update()
	{
		if (isGameOver)
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				SceneManager.LoadScene(1);
			}
		}
	}
	
	void OnGameOver(){
		gameOverScreen.SetActive(true);
		secondsDelayedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		isGameOver = true;
	}

}
