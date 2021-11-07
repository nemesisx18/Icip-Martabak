using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_2 : MonoBehaviour
{
    [SerializeField] private CustSpawn custSpawn;
    [SerializeField] private ShopMenu shopMenu;
    [SerializeField] private GameManager gameManager;
    public GameTimer gameTimer;

    public GameObject dishUI;

    private AudioSource audioCoin;
    public AudioClip clipCoin;

    public float walkSpeed = 1.0f;
    public float maxWalk;
    public float walkingDirection = 1.0f;
    public float respawnUI;

    float originalX;
    Animator anim;
    Vector2 walkAmount;

    public void Setup2(CustSpawn _custSpawn)
    {
        custSpawn = _custSpawn;
        shopMenu = custSpawn.GetComponent<ShopMenu>();
        gameManager = custSpawn.GetComponent<GameManager>();
        gameTimer = custSpawn.GetComponent<GameTimer>();
    }

    void Start()
    {
        this.originalX = this.transform.position.x;
        anim = GetComponent<Animator>();
        audioCoin = gameObject.AddComponent<AudioSource>();
        audioCoin.clip = clipCoin;

        StartCoroutine(WaitSpawn());

        anim.SetBool("isIdle", false);
    }

    void Update()
    {
        if (gameTimer.playAds == false && gameManager.pausedMenu == false && gameManager.isShopOpen == false)
        {
            dishUI.SetActive(true);
        }
        else
        {
            dishUI.SetActive(false);
        }

        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection < 0.0f && transform.position.x <= originalX + maxWalk)
        {
            walkingDirection = 0f;
        }

        transform.Translate(walkAmount);

        //if (gameManager.level1)
        //{
        //    PesananKeju();
        //}
        //if (gameManager.level2)
        //{
        //    PesananCokKej();
        //}
        //if (gameManager.level3)
        //{
        //    //isi pesanan
        //}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.level1 || gameManager.level3)
        {
            if (collision.tag == "TB_Keju")
            {
                shopMenu.moneyAmount += 22000;
                audioCoin.Play();

                Destroy(this.gameObject);

                custSpawn.custQty -= 1;
                custSpawn.isSpawned = false;

                gameManager.customerDone += 1;
                gameManager.isButter = false;
                gameManager.isKeju = false;

                Destroy(collision.gameObject);

                Debug.Log("ini rasa keju");
            }
        }

        if (gameManager.level2)
        {
            if (collision.tag == "TB_CokKej")
            {
                shopMenu.moneyAmount += 22000;
                audioCoin.Play();

                Destroy(this.gameObject);

                custSpawn.custQty -= 1;
                custSpawn.isSpawned = false;

                gameManager.customerDone += 1;
                gameManager.isButter = false;
                gameManager.isChoco = false;
                gameManager.isKeju = false;

                Destroy(collision.gameObject);

                Debug.Log("ini rasa coklat keju");
            }
        }
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(respawnUI);
        dishUI.SetActive(true);
        anim.SetBool("isIdle", true);
    }

    #region Menu Pesanan

    //private void PesananChoco()
    //{
    //    if (gameManager.isChoco && gameManager.isButter)
    //    {
    //        gameManager.tbCoklat.SetActive(true);
    //    }
    //    else
    //    {
    //        gameManager.tbCoklat.SetActive(false);
    //    }
    //}

    //private void PesananKeju()
    //{
    //    if (gameManager.isKeju && gameManager.isButter)
    //    {
    //        gameManager.tbKeju.SetActive(true);
    //    }
    //    else
    //    {
    //        gameManager.tbKeju.SetActive(false);
    //    }
    //}

    //private void PesananNut()
    //{
    //    if (gameManager.isNut && gameManager.isButter)
    //    {
    //        gameManager.tbKacang.SetActive(true);
    //    }
    //    else
    //    {
    //        gameManager.tbKacang.SetActive(false);
    //    }
    //}

    //private void PesananCokKej()
    //{
    //    if (gameManager.isChoco && gameManager.isButter && gameManager.isKeju)
    //    {
    //        gameManager.tbCokKej.SetActive(true);
    //    }
    //    else
    //    {
    //        gameManager.tbCokKej.SetActive(false);
    //    }
    //}

    //private void PesananCokKac()
    //{
    //    if (gameManager.isChoco && gameManager.isButter && gameManager.isNut)
    //    {
    //        gameManager.tbCokKac.SetActive(true);
    //    }
    //    else
    //    {
    //        gameManager.tbCokKac.SetActive(false);
    //    }
    //}

    //private void PesananKacKej()
    //{
    //    if (gameManager.isNut && gameManager.isButter && gameManager.isKeju)
    //    {
    //        gameManager.tbKacKej.SetActive(true);
    //    }
    //    else
    //    {
    //        gameManager.tbKacKej.SetActive(false);
    //    }
    //}

    #endregion
}
