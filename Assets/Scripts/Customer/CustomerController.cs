using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
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

    public string gameObjectTag1;
    public string gameObjectTag2;
    public string gameObjectTag3;

    float originalX;
    Animator anim;
    Vector2 walkAmount;

    public void SetupCustomer(CustSpawn _custSpawn)
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

        //kustomer gerak
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection < 0.0f && transform.position.x <= originalX + maxWalk)
        {
            walkingDirection = 0f;
        }

        transform.Translate(walkAmount);
    }

    public void DoneLeft()
    {
        walkAmount.x = 3f * walkSpeed * Time.deltaTime;
        transform.Translate(walkAmount);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.level1)
        {
            if (collision.tag == gameObjectTag1)
            {
                shopMenu.moneyAmount += 22000;
                audioCoin.Play();

                Destroy(collision.gameObject);
                Destroy(this.gameObject);

                custSpawn.custQty -= 1;
                custSpawn.isSpawned = false;

                gameManager.customerDone += 1;
                gameManager.isButter = false;
                gameManager.isChoco = false;
                gameManager.isNut = false;
                gameManager.isKeju = false;
            }
        }

        if (gameManager.level2)
        {
            if (collision.tag == gameObjectTag2)
            {
                shopMenu.moneyAmount += 22000;
                audioCoin.Play();

                Destroy(collision.gameObject);
                Destroy(this.gameObject);

                custSpawn.custQty -= 1;
                custSpawn.isSpawned = false;

                gameManager.customerDone += 1;
                gameManager.isButter = false;
                gameManager.isChoco = false;
                gameManager.isNut = false;
                gameManager.isKeju = false;
            }
        }
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(respawnUI);
        dishUI.SetActive(true);
        anim.SetBool("isIdle", true);
    }
}
