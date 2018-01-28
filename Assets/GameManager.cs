﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject GameOverPrefabSPECT;
	public GameObject GameOverPrefabJOUEUR;

	public GrannyScreenDisplayer grannyScreen;
	public Text currentScoreText;
	public Text finalScoreText;

	public PlayerDeath death;
	public int currentSpeedLevel;
	public int maxSpeedLevel = 4;

	public float currentScore = 0f;
	public float scoreMult = 5f;
	float finalScore = 0f;
	public int numberOfCloseCalls = 0;
	
	private void Awake() {
		SetGameOverCanvasState(false);
		currentScore = 0f;
		currentSpeedLevel = 0;
	}

	// Update is called once per frame
	void Update () {
		if(death.isDead){
			SetGameOverCanvasState(true);
			finalScore = currentScore + numberOfCloseCalls * 100f;
			finalScoreText.text = "Score : " + finalScore.ToString("0000#");
			currentScoreText.text = "";
		}else{
			currentScore += Time.deltaTime * scoreMult * currentSpeedLevel;
			currentScoreText.text = "Score : " + currentScore.ToString("0000#");
		}

		//Testeur
		if(Input.GetKeyDown(KeyCode.Space)){
			ChangeSpeedLevel(1);
		}
	}

	void ChangeSpeedLevel(int amount){
		currentSpeedLevel += amount;
		if(currentSpeedLevel >= maxSpeedLevel){
			currentSpeedLevel -= amount;
		}else{
			grannyScreen.SetSourceImage(currentSpeedLevel);
			grannyScreen.TriggerAnimation(true);
		}
	}

	public void Quit(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit ();
	}

	public void Continue(){
		Scene ActiveScene = SceneManager.GetActiveScene();
		SceneManager.LoadSceneAsync(ActiveScene.name);
	}

	void SetGameOverCanvasState(bool b){
		GameOverPrefabSPECT.SetActive(b);
		GameOverPrefabJOUEUR.SetActive(b);
	}
}
