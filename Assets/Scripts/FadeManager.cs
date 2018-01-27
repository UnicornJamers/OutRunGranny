using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

    public Image overlayImage;
    private float durationIn;
    private float durationOut;
    private bool isInTransition;
    private float transition;
    private bool isShowing;

    public void Flash(float durationIn, float durationOut)
    {
        isShowing = true;
        isInTransition = true;
        this.durationIn = durationIn;
        this.durationOut = durationOut;
        transition = 0;
    }

    void Update()
    {
        if (!isInTransition)
        {
            if (!isShowing) { return; }

			transition += Time.deltaTime * (1 / durationOut);
            overlayImage.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), transition);
			if (transition > 1)
            {
				isShowing = false;
            }
        }
        else
        {
            transition += Time.deltaTime * (1 / durationIn);
            //overlayImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transition);
			overlayImage.color = Color.white;
			if (transition > 1)
            {
				isInTransition = false;
				transition = 0;
            }
        }
    }
}
