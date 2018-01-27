using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour {

	public FadeManager fadeManager;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) {
			fadeManager.Flash(1f, 5f);
		}
	}
}
