using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrannyScreenDisplayer : MonoBehaviour {
	public GameObject grannyPanel;
	Animator animator;

	private void Start() {
		animator = grannyPanel.GetComponent<Animator>();
	}

	private void Update() {

		if(Input.GetKey(KeyCode.Space)){
			TriggerAnimation(true);
			StartCoroutine("Pause");
		}
		if(IsAnimatorPlaying()){
			TriggerAnimation(false);
		}
	}

	public void TriggerAnimation(bool b){
			animator.SetBool("AnimIsActive", b);
	}

	private bool IsAnimatorPlaying(){
		bool b = animator.GetCurrentAnimatorStateInfo(0).IsName("GrannyScreenAnimation");
		//Debug.Log(b);
		return b;
	}

	private IEnumerator Pause(){
		Time.timeScale = .1f;
		float pauseEndTime = Time.realtimeSinceStartup + 3;

		while(Time.realtimeSinceStartup < pauseEndTime){
			yield return 0;
		}
		Time.timeScale = 1f;
	}
}
