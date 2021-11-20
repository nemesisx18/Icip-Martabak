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
    public AudioSource audioWin;
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

    [Header("Chacha Item")]
    public int chaChaQty;
    public bool isChaCha = false;

    public Text chaChaText;
    public GameObject[] chaChaItem;

    [Header("Matcha Item")]
    public int matchaQty;
    public bool isMatcha = false;

    public Text matchaText;
    public GameObject[] matchaItem;

    [Header("Strawberry Item")]
    public int strawberryQty;
    public bool isStrawberry = false;

    public Text strawberryText;
    public GameObject[] strawberryItem;

    [Header("Corn Item")]
    public int cornQty;
    public bool isCorn = false;

    public Text cornText;
    public GameObject[] cornItem;

    [Header("Level 2")]
    public GameObject tbCokKej;
    public GameObject tbCokKac;
    public GameObject tbKacKej;

    [Header("Level 3")]
    public GameObject tbSpesial;

    [SerializeField] private GameObject prepCanvas;
    [SerializeField] private GameObject dropPointInstance;

    public bool isStart;

    void Start()
    {
        Time.timeScale = 1;
        
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");

        PlayerPrefs.SetInt("MoneyAmount", modalAwal);

        prepCanvas.SetActive(true);

        isStart = true;
    }

    void Update()
    {
        if (isStart == true)
        {
            moneyText.text = moneyAmount.ToString();

            //List Item
            ItemMentega();
            ItemChoco();
            ItemNut();
            ItemKeju();

            if (level3)
            {
                ItemChaCha();
                ItemMatcha();
                ItemStrawberry();
                ItemCorn();
            }

            if (isShopOpen == true)
            {
                prepCanvas.SetActive(true);
            }

            if (customerDone == targetKustomer)
            {
                winCanvas.SetActive(true);
                Debug.Log("lol");
                audioWin.PlayOneShot(clipWin);
                Time.timeScale = 0;
                isStart = false;
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
                }
                else
                {
                    tbCokKej.SetActive(false);
                }

                if (isButter && isChoco && isNut)
                {
                    tbCokKac.SetActive(true);
                }
                else
                {
                    tbCokKac.SetActive(false);
                }

                if (isButter && isNut && isKeju)
                {
                    tbKacKej.SetActive(true);
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

            else if (level3)
            {
                if (isButter && isChaCha && isMatcha && isStrawberry && isCorn)
                {
                    tbSpesial.SetActive(true);
                }
                else
                {
                    tbSpesial.SetActive(false);
                }

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
        }

        else
        {
            Debug.Log("game selesai");
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

    void ItemChaCha()
    {
        chaChaText.text = chaChaQty.ToString();

        for(int i = 0; i < chaChaItem.Length; i++)
        {
            if (chaChaQty >= 1)
                chaChaItem[i].SetActive(true);
            else
                chaChaItem[i].SetActive(false);
        }
    }

    void ItemMatcha()
    {
        matchaText.text = matchaQty.ToString();

        for (int i = 0; i < matchaItem.Length; i++)
        {
            if (matchaQty >= 1)
                matchaItem[i].SetActive(true);
            else
                matchaItem[i].SetActive(false);
        }
    }

    void ItemStrawberry()
    {
        strawberryText.text = strawberryQty.ToString();

        for (int i = 0; i < strawberryItem.Length; i++)
        {
            if (strawberryQty >= 1)
                strawberryItem[i].SetActive(true);
            else
                strawberryItem[i].SetActive(false);
        }
    }

    void ItemCorn()
    {
        cornText.text = cornQty.ToString();

        for (int i = 0; i < cornItem.Length; i++)
        {
            if (cornQty >= 1)
                cornItem[i].SetActive(true);
            else
                cornItem[i].SetActive(false);
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

    public void FinishLevel()
    {
        SceneManager.LoadScene("MainMenu");
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
