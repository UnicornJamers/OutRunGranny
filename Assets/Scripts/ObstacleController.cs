using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public GlobalSpeed speed;
    public int lane;
    public string type;
    public List<AudioData> carKlaxon;
    public List<AudioData> truckKlaxon;
    public AudioManager audioMngr;
    public float timerDelay;

    private bool isAfraid = false;
    private float timer;

    void Awake()
    {
      isAfraid = Random.value < 0.2f;
      timer = 0f; 
      audioMngr = GameObject.FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        transform.position += new Vector3(-1 * Time.deltaTime * speed.minimalSpeed, 0, 0);

        if(isAfraid) {
          timer += Time.deltaTime;
          if(timer > timerDelay && !audioMngr.efxSource.isPlaying) {
            isAfraid = false;
            List<AudioData> audioData;
            audioData = type == VehicleType.Car ? carKlaxon : truckKlaxon;
            audioMngr.RandomizeSfx(audioData.ToArray());
          }
        }

    }
}

public static class VehicleType
{
    public const string Car = "CAR";
    public const string Truck = "TRUCK";
}
