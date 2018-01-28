﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject GameOverPrefabSPECT;
	public GameObject GameOverPrefabJOUEUR;

	public GrannyScreenDisplayer grannyScreen;
	public GameObject ScorePanel;
	public Text finalScoreText;

	public PlayerDeath death;
	public int currentSpeedLevel;

	public float currentScore = 0f;
	public float scoreMult = 5f;
	float finalScore = 0f;
	public int numberOfCloseCalls = 0;

	// Use this for initialization
	void Start () {
	}
	
	private void Awake() {
		SetGameOverCanvasState(false);
		currentScore = 0f;
		currentSpeedLevel = 1;
	}

	// Update is called once per frame
	void Update () {
		if(death.isDead){
			SetGameOverCanvasState(true);
			finalScore = currentScore + numberOfCloseCalls * 100f;
			finalScoreText.text = "Score : " + finalScore.ToString();
		}else{
			currentScore += Time.deltaTime * scoreMult * currentSpeedLevel;
		}
	}

	void ChangeSpeedLevel(int amount){
		currentSpeedLevel += amount;
	}

	public void Quit(){
		Debug.Log("QUIT");
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