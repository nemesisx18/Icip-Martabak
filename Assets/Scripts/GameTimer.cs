using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 10;

    public bool timerIsRunning = false;
    public bool playAds = false;

    public Text timeText;
    public GameObject loseUI;
    public GameObject adsGame;
    public GameObject popAds;
    public AudioClip clip;
    private AudioSource audioLose;
    public AudioSource bgmGame;

    public ShopMenu shopMenu;
    
    GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        audioLose = gameObject.AddComponent<AudioSource>();
        audioLose.clip = clip;

        // Starts the timer automatically
        StartCoroutine(StartTime());
    }

    void Update()
    {
        RunTimer();
    }

    public void RunTimer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameManager.pausedMenu = true;
                Time.timeScale = 0;
                loseUI.SetActive(true);
                audioLose.Play();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    

    public void ResumeGame()
    {
        loseUI.SetActive(false);
        gameManager.pausedMenu = false;
        Time.timeScale = 1;
    }

    public void BackGame()
    {
        Debug.Log("back to game");

        Time.timeScale = 1;
        shopMenu.moneyAmount += 50000;
        timeRemaining += 30;
        timerIsRunning = true;
        gameManager.pausedMenu = false;
        playAds = false;
        popAds.SetActive(false);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void PlayAds()
    {
        adsGame.SetActive(true);
        playAds = true;
        Time.timeScale = 0;
        StartCoroutine(AdsCount());
        bgmGame.mute = !bgmGame.mute;
        loseUI.SetActive(false);
    }

    IEnumerator StartTime()
    {
        yield return new WaitForSeconds(5f);
        timerIsRunning = true;
    }

    IEnumerator AdsCount()
    {
        yield return new WaitForSecondsRealtime(13);
        Time.timeScale = 1;
        bgmGame.mute = !bgmGame.mute;
        adsGame.SetActive(false);
        popAds.SetActive(true);
    }

}
