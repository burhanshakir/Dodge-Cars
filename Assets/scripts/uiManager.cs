using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public Button[] buttons;
	public Text scoreText;
	int score;
	bool isGameOver;

	// Use this for initialization
	void Start () {
		score = 0;

		isGameOver = false;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score : " + score;
	}

	public void Play()
	{
		Time.timeScale = 1;
		UnityEngine.SceneManagement.SceneManager.LoadScene ("level1");
	}


	public void Pause()
	{
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} 
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}

	void scoreUpdate(){

		if (!isGameOver) {

			score += 1;

		}
	}

	public void gameOver()
	{
		isGameOver = true;
		Time.timeScale = 0;
		foreach (Button button in buttons) {
		
			button.gameObject.SetActive(true);
		}

	}

	public void Menu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("menuScene");
	}

	public void Exit()
	{
		Application.Quit ();
	}



}
