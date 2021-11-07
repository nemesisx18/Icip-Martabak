using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInterface : MonoBehaviour
{
    [SerializeField] private GameObject prepCanvas;

    public GameObject winCanvas;
    public GameObject pauseUI;

    public static int moneyAmount;
    public bool isShopOpen = true;
    public bool pausedMenu = false;

    public void GoToShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        prepCanvas.SetActive(true);
        isShopOpen = true;
    }

    public void PauseMenu()
    {
        pauseUI.SetActive(true);
        pausedMenu = true;
        Time.timeScale = 0;
    }

    public void StopPause()
    {
        pauseUI.SetActive(false);
        pausedMenu = false;
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }

    public void GojekOrder()
    {
        Application.OpenURL("https://gofood.co.id/english/bandar-lampung/restaurant/martabak-bangka-anugrah-koga-za-pagar-alam-0bfeb9d3-cd37-4139-bcc2-78fbc6f90f05");
    }

    public void GrabOrder()
    {
        Application.OpenURL("https://food.grab.com/id/en/restaurant/martabak-bangka-anugrah-koga-gedong-meneng-delivery/6-C2MEATMFCFAYNT");
    }

    public void WhatOrder()
    {
        Application.OpenURL("https://api.whatsapp.com/send?phone=6288276718773");
    }
}
