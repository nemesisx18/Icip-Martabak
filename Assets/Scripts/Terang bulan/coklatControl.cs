using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coklatControl : MonoBehaviour
{
    public GameObject prefabCoklat;

    public Transform spawnTB;

    public GameManager gameManager;

    public Rigidbody2D selectedObject;
    Vector3 offset;
    Vector3 mousePosition;

    void Update()
    {
        if (gameObject.activeInHierarchy)
            Debug.Log("this" + gameObject.name + "active");
        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject)
            {
                //selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }

    void FixedUpdate()
    {
        if (selectedObject)
        {
            selectedObject.MovePosition(mousePosition + offset);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Kemas")
        {
            Instantiate(prefabCoklat, spawnTB.transform);
            gameManager.isButter = false;
            gameManager.isChoco = false;
            gameManager.isNut = false;
            gameManager.isKeju = false;
            gameManager.isChaCha = false;
            gameManager.isMatcha = false;
            gameManager.isStrawberry = false;
            gameManager.isCorn = false;
        }
    }
}
