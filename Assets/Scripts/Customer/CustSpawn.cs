using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustSpawn : MonoBehaviour
{
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;

    public int custQty;

    public bool isSpawned = false;
    public bool isFirst = true;

    public GameObject[] sliderInstance;
    public GameObject[] prefabSpawnA;
    public GameObject[] prefabSpawnB;
    public Transform originalPos;

    GameManager gameManager;

    private GameObject customerInstance;
    private GameObject customerInstance_2;
    private GameObject customerInstance_3;
    private GameObject customerInstance_4;

    [Header("Customer Info")]
    public GameObject customerObject;
    public GameObject customerObject_2;
    public GameObject customerObject_3;
    public GameObject customerObject_4;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        //set customer
        customerInstance = customerObject;
        customerInstance_2 = customerObject_2;
        customerInstance_3 = customerObject_3;
        customerInstance_4 = customerObject_4;

        //CustomerController cc = customerInstance[customerInstance.Length].GetComponent<CustomerController>();
        //cc.SetupCustomer(GetComponent<CustSpawn>());

        //customer 1
        Customer_1 cs1 = customerInstance.GetComponent<Customer_1>();
        cs1.Setup1(GetComponent<CustSpawn>());

        //customer 2
        Customer_2 cs2 = customerInstance_2.GetComponent<Customer_2>();
        cs2.Setup2(GetComponent<CustSpawn>());

        //customer 3
        Customer_3 cs3 = customerInstance_3.GetComponent<Customer_3>();
        cs3.Setup3(GetComponent<CustSpawn>());

        //customer 4
        Customer_4 cs4 = customerInstance_4.GetComponent<Customer_4>();
        cs4.Setup4(GetComponent<CustSpawn>());

        //find slider time
        for (int i = 0; i < sliderInstance.Length; i++)
        {
            SliderTimeBar slider = sliderInstance[i].GetComponent<SliderTimeBar>();
            slider.SetManager(GetComponent<CustSpawn>());
        }
    }

    void Update()
    {
        if (custQty <= 0)
            custQty = 0;
        
        if (gameManager.isShopOpen == false)
        {
            elapsedTime += Time.deltaTime;
        }

        if (custQty < 2 && custQty == 0 || isFirst == true)
        {
            if (elapsedTime > secondsBetweenSpawn)
            {
                //random fixed spawn
                StartCoroutine(TimedSpawn());
            }
        }
    }

    #region spawn_customer

    IEnumerator TimedSpawn()
    {
        SpawnCustomer();

        yield return new WaitForSeconds(0.1f);
        SpawnCustomer2();
    }

    void SpawnCustomer()
    {
        elapsedTime = 0;
        Debug.Log(true);

        //Vector2 spawnPosition = new Vector2 (7.5f, -1f);

        GameObject newCustomer = (GameObject)Instantiate(prefabSpawnA[Random.Range(0, prefabSpawnA.Length)], originalPos.position, Quaternion.Euler(0, 0, 0));

        custQty += 1;

        isSpawned = true;
        isFirst = false;
    }

    void SpawnCustomer2()
    {
        elapsedTime = 0;
        Debug.Log(true);

        //Vector2 spawnPosition = new Vector2(7.5f, 2.5f);

        GameObject newCustomer = (GameObject)Instantiate(prefabSpawnB[Random.Range(0, prefabSpawnB.Length)], originalPos.position, Quaternion.Euler(0, 0, 0));

        custQty += 1;

        isSpawned = true;
        isFirst = false;
    }

    #endregion
}
