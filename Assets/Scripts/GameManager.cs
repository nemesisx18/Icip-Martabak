using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text moneyText;
    public GameObject winCanvas;
    public GameObject pauseUI;
    private AudioSource audioWin;
    public AudioClip clipWin;

    public int customerDone;
    public int targetKustomer;
    public int modalAwal;
    public static int moneyAmount;
    
    public bool isShopOpen = true;
    public bool pausedMenu = false;

    [Header("Level info")]
    public bool level1;
    public bool level2;
    public bool level3;

    public bool isCooked;

    private GameObject TBinstance;
    public GameObject TBObject;

    [Header("Mentega Item")]
    public int butterQty;
    public bool isButterSold = false;
    public bool isButter = false;
    
    public Text butterText;
    public GameObject tbBase;
    public GameObject[] mentegaItem;

    [Header("Coklat Item")]
    public int chocoQty;
    public bool isChoco = false;

    public Text chocoText;
    public GameObject tbCoklat;
    public GameObject[] chocoItem;

    [Header("Nut Item")]
    public int nutQty;
    public bool isNut = false;

    public Text nutText;
    public GameObject tbKacang;
    public GameObject[] nutItem;

    [Header("Keju Item")]
    public int kejuQty;
    public bool isKeju = false;

    public Text kejuText;
    public GameObject tbKeju;
    public GameObject[] kejuItem;

    [Header("Level 2")]
    public GameObject tbCokKej;
    public GameObject tbCokKac;
    public GameObject tbKacKej;

    [SerializeField] private GameObject prepCanvas;
    [SerializeField] private GameObject dropPointInstance;

    void Start()
    {
        Time.timeScale = 1;
        
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");

        PlayerPrefs.SetInt("MoneyAmount", modalAwal);

        prepCanvas.SetActive(true);

        audioWin = gameObject.AddComponent<AudioSource>();
        audioWin.clip = clipWin;

        //set TB instance
        TBinstance = TBObject;

        TBControl tb = TBinstance.GetComponent<TBControl>();
        tb.SetupTB(GetComponent<GameManager>());
    }

    void Update()
    {
        moneyText.text = moneyAmount.ToString();

        //List Item
        ItemMentega();
        ItemChoco();
        ItemNut();
        ItemKeju();

        if (isShopOpen == true)
        {
            prepCanvas.SetActive(true);
        }

        if (customerDone == targetKustomer)
        {
            winCanvas.SetActive(true);
            audioWin.Play();
            Time.timeScale = 0;
        }

        if (isButter)
        {
            tbBase.SetActive(true);
        }
        else
        {
            tbBase.SetActive(false);
        }

        if (level1)
        {
            if (isButter && isChoco)
            {
                tbCoklat.SetActive(true);
            }
            else
            {
                tbCoklat.SetActive(false);
            }

            if (isButter && isKeju)
            {
                tbKeju.SetActive(true);
            }
            else
            {
                tbKeju.SetActive(false);
            }

            if (isButter && isNut)
            {
                tbKacang.SetActive(true);
            }
            else
            {
                tbKacang.SetActive(false);
            }
        }

        else if (level2)
        {
            if (isButter && isChoco && isKeju)
            {
                tbCokKej.SetActive(true);
                Debug.Log("cokalt keju");
            }
            else
            {
                tbCokKej.SetActive(false);
            }

            if (isButter && isChoco && isNut)
            {
                tbCokKac.SetActive(true);
                Debug.Log("cokalt kacang");
            }
            else
            {
                tbCokKac.SetActive(false);
            }

            if (isButter && isNut && isKeju)
            {
                tbKacKej.SetActive(true);
                Debug.Log("kacang keju");
            }
            else
            {
                tbKacKej.SetActive(false);
            }

            if (isButter && isKeju)
            {
                tbKeju.SetActive(true);
            }
            else
            {
                tbKeju.SetActive(false);
            }
        }
    }

    void ItemMentega()
    {
        butterText.text = butterQty.ToString();

        for (int i = 0; i < mentegaItem.Length; i++)
        {
            if (butterQty >=1)
                mentegaItem[i].SetActive(true);
            else
                mentegaItem[i].SetActive(false);
        }
    }

    void ItemChoco()
    {
        chocoText.text = chocoQty.ToString();

        for (int i = 0; i < chocoItem.Length; i++)
        {
            if (chocoQty >= 1)
                chocoItem[i].SetActive(true);
            else
                chocoItem[i].SetActive(false);
        }
    }

    void ItemNut()
    {
        nutText.text = nutQty.ToString();

        for (int i = 0; i < nutItem.Length; i++)
        {
            if (nutQty >= 1)
                nutItem[i].SetActive(true);
            else
                nutItem[i].SetActive(false);
        }
    }

    void ItemKeju()
    {
        kejuText.text = kejuQty.ToString();

        for(int i = 0; i < kejuItem.Length; i++)
        {
            if (kejuQty >= 1)
                kejuItem[i].SetActive(true);
            else
                kejuItem[i].SetActive(false);
        }
    }

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
