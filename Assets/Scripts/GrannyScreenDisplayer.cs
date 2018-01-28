using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrannyScreenDisplayer : MonoBehaviour
{
    public GameObject grannyPanel;
    public List<Sprite> speedLevelsImages;
    Animator animator;
    public GameManager gameManager;


    private void Awake()
    {
        animator = grannyPanel.GetComponent<Animator>();
    }

    public void TriggerAnimation(bool b)
    {
        animator.SetBool("AnimIsActive", b);
    }

    private bool IsAnimatorPlaying()
    {
        bool b = animator.GetCurrentAnimatorStateInfo(0).IsName("GrannyScreenAnimation");
        return b;
    }

    public void SetSourceImage(int currentSpeedLevel)
    {
        if (speedLevelsImages[currentSpeedLevel - 1] != null)
        {
            grannyPanel.GetComponent<Image>().sprite = speedLevelsImages[currentSpeedLevel - 1];
        }
        else
        {
            return;
        }
    }

    private IEnumerator Pause()
    {
        Time.timeScale = .1f;
        float pauseEndTime = Time.realtimeSinceStartup + 3;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
    }

    public void StartNewLevel() {
        TriggerAnimation(false);
        gameManager.StartNewLevel();
	}
}
