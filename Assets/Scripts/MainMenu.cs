using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	bool QuitPopUpActive = false;
	public GameObject quitPopUpPanel;
	public Button quitConfirmationButton;
	public CanvasGroup MainMenuCanvasGroup;

	public void NewGame(){
		Debug.Log("NEW GAME");
		SceneManager.LoadScene("Main");
	}

	public void QuitPopUp(bool b){
		QuitPopUpActive = b;
		if(QuitPopUpActive){
			Debug.Log("QUIT POP UP");
		}else{
			Debug.Log("QUIT QUIT POP UP");
		}
		quitPopUpPanel.SetActive(QuitPopUpActive);
	}

	public void Quit(){
		Debug.Log("QUIT");
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit ();
	}
}
