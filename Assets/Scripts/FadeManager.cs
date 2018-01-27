using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

    public Image overlayImage;
    public float duration;
    public bool isInTransition;
    public bool isShowing;

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
    }

    void Update()
    {
        if (!isInTransition) { return; }

		overlayImage.color = Color.Lerp(new Color(1,1,1,0), Color.white, Time.deltaTime * (1/duration));
    }
}
