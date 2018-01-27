using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public GlobalSpeed speed;
    public int lane;

    void Update()
    {
		transform.position += new Vector3(-1 * Time.deltaTime * speed.minimalSpeed, 0, 0);
    }
}
