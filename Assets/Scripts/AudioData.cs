using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Globals/Audio")]
public class AudioData : ScriptableObject {

	public AudioClip clip;
	public int priority;
}
