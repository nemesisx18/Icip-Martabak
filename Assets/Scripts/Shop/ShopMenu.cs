using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] public int moneyAmount;
    [SerializeField] private GameObject prepCanvas;
    
    //public int butterQty;

    [Header("Test")]
    public Text moneyAmountText;
    public Text itemPrice;

    public Button[] buyButton;
    public Button butterButton;

    public GameObject videoButton;
    public AudioClip clip;
    public AudioSource audioSFX;

    GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();

        for(int i = 0; i < buyButton.Length; i++)
        {
            if (moneyAmount >= 10000)
                buyButton[i].interactable = true;
            else
                buyButton[i].interactable = false;
        }

        if (moneyAmount >= 5000)
            butterButton.interactable = true;
        else
            butterButton.interactable = false;

        if(moneyAmount <= 10000)
        {
            videoButton.SetActive(true);
        }
        else
        {
            videoButton.SetActive(false);
        }
    }

    public void ButterItem()
    {
        moneyAmount -= 5000;
        gameManager.butterQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void ChocoItem()
    {
        moneyAmount -= 10000;
        gameManager.chocoQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void NutItem()
    {
        moneyAmount -= 10000;
        gameManager.nutQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void KejuItem()
    {
        moneyAmount -= 10000;
        gameManager.kejuQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void ChaChaItem()
    {
        moneyAmount -= 10000;
        gameManager.chaChaQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void MatchaItem()
    {
        moneyAmount -= 10000;
        gameManager.matchaQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void StrawberryItem()
    {
        moneyAmount -= 10000;
        gameManager.strawberryQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void CornItem()
    {
        moneyAmount -= 10000;
        gameManager.cornQty += 1;
        audioSFX.PlayOneShot(clip);
    }

    public void FinishPrep()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        prepCanvas.SetActive(false);

        gameManager.isShopOpen = false;
    }

    public void ResetPlayerPrefs()
    {
        moneyAmount = 0;
        PlayerPrefs.DeleteAll();
    }
}
