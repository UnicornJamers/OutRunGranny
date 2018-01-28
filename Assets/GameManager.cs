using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverPrefabSPECT;
    public GameObject GameOverPrefabJOUEUR;

    public AudioManager audioMngr;
    public AudioData flashAudio;
    public groundTextureOffset planespeed;

    public GameObject[] obsAnimationHandler;
    public GlobalSpeed speed;
	public Spawn spawner;

    public GrannyScreenDisplayer grannyScreen;
    public Text currentScoreText;
    public Text finalScoreText;

    public PlayerDeath death;
    public int currentSpeedLevel;
    public int maxSpeedLevel = 4;

    public float currentScore = 0f;
    public float scoreMult = 5f;
    float finalScore = 0f;
    public int numberOfCloseCalls = 0;

    private float[] scoreMilestone = new float[] { 20, 20, 20, 20 };
    private float currentMilestone;
    private float timer;

    private void Awake()
    {
        SetGameOverCanvasState(false);
        currentScore = 0f;
        currentSpeedLevel = 1;
        obsAnimationHandler[currentSpeedLevel - 1].SetActive(true);
		speed.minimalSpeed = currentSpeedLevel * 10f;
        currentMilestone = scoreMilestone[currentSpeedLevel-1];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (death.isDead)
        {
            SetGameOverCanvasState(true);
            finalScore = currentScore + numberOfCloseCalls * 100f;
            finalScoreText.text = "Score : " + finalScore.ToString("0000#");
            currentScoreText.text = "";
        }
        else
        {
            currentScore += Time.deltaTime * scoreMult * currentSpeedLevel;
            currentScoreText.text = "Score : " + currentScore.ToString("0000#");
        }

        //Testeur
        if (timer >= currentMilestone)
        {
            timer = 0f;
            ChangeSpeedLevel(1);
        }
    }

    void ChangeSpeedLevel(int amount)
    {
        currentSpeedLevel += amount;
        if (currentSpeedLevel >= maxSpeedLevel)
        {
            currentSpeedLevel -= amount;
        }
        else
        {
            grannyScreen.SetSourceImage(currentSpeedLevel);
            audioMngr.PlaySingle(flashAudio);
			spawner.canSpawn = false;
            grannyScreen.TriggerAnimation(true);
            obsAnimationHandler[currentSpeedLevel-2].SetActive(false);
			obsAnimationHandler[currentSpeedLevel-1].SetActive(true);
            currentMilestone = scoreMilestone[currentSpeedLevel-1];
            audioMngr.GearUp(currentSpeedLevel-1);
            planespeed.speed += 0.05f;
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Continue()
    {
        Scene ActiveScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(ActiveScene.name);
    }

    void SetGameOverCanvasState(bool b)
    {
        GameOverPrefabSPECT.SetActive(b);
        GameOverPrefabJOUEUR.SetActive(b);
    }

    public void StartNewLevel() {
		spawner.canSpawn = true;
        speed.minimalSpeed = currentSpeedLevel * 10f;
	}
}
