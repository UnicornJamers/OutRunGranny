using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpeed : MonoBehaviour {

	public GlobalSpeed speed;
	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
	}

	void Update () {
		anim.SetFloat("speed", speed.minimalSpeed);
	}
}
