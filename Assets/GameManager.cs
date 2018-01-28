using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject GameOverPrefabSPECT;
	public GameObject GameOverPrefabJOUEUR;

	public PlayerDeath death;

	// Use this for initialization
	void Start () {
	}
	
	private void Awake() {
		SetGameOverCanvasState(false);
	}

	// Update is called once per frame
	void Update () {
		if(death.isDead){
			SetGameOverCanvasState(true);
		}
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
