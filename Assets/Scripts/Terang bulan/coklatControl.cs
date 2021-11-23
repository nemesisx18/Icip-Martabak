using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coklatControl : MonoBehaviour
{
    public GameObject prefabCoklat;

    public Transform spawnTB;

    public GameManager gameManager;

    private Rigidbody2D selectedObject;
    public LayerMask layerMask;
    Vector3 offset;
    Vector3 mousePosition;

    private float defaultX;
    private float defaultY;

    void Start()
    {
        defaultX = transform.position.x;
        defaultY = transform.position.y;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, layerMask);

            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kemas")
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

    void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = new Vector3(defaultX, defaultY);
    }
}
