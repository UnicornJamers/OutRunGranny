using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
			
        }
    }
}
