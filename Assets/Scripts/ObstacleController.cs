using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public GlobalSpeed speed;
    public int lane;
    public string type;

    void Update()
    {
		    transform.position += new Vector3(-1 * Time.deltaTime * speed.minimalSpeed, 0, 0);
    }
}

public static class VehicleType {
  public const string Car = "CAR";
  public const string Truck = "TRUCK";
}
