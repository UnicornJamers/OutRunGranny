using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTextureOffset : MonoBehaviour {
	// Update is called once per frame

	public float speed = 5.0f;
	float offset = 0f;
	Renderer r;

	void Start() {
		r = GetComponent<Renderer>();
	}


	void Update () {
		offset += Time.deltaTime * speed;
		r.material.SetTextureOffset("_MainTex", new Vector2 (-offset, 0));
	}
}
