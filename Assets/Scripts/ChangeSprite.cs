using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite sprite;
	public bool flipIt;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player") {

			if(other.GetComponent<PlayerDeath>().isDead){
				other.GetComponent<SpriteRenderer>().sprite = null;
			}else{
				var renderObj = other.GetComponent<SpriteRenderer>();
				renderObj.flipX = flipIt;
				renderObj.sprite = sprite;
			}
		}		
	}
}
