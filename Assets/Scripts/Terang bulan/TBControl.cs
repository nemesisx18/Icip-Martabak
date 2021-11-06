using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBControl : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public SpriteRenderer spriteRenderer;
    public Sprite adonanMatang;
    public Sprite adonanMasak;
    public Sprite coklat;
    public Sprite keju;
    public Sprite kacang;

    //public GameObject prefabTB;
    //public Transform tempatTB;
    //public Transform destTrans;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float firstY;
    private float firstX;

    public void SetupTB(GameManager _gameManager)
    {
        gameManager = _gameManager;
    }
    
    void Start()
    {
        StartCoroutine(CookDough());
    }

    //void OnMouseDown()
    //{
    //    firstY = transform.position.y;
    //    firstX = transform.position.x;
    //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //}

    //void OnMouseDrag()
    //{
    //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

    //    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    //    transform.position = curPosition;
    //}

    //private void OnMouseUp()
    //{
    //    transform.position = destTrans.transform.position;
    //}

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    IEnumerator CookDough()
    {
        spriteRenderer.sprite = adonanMasak;
        gameManager.isCooked = false;
        yield return new WaitForSeconds(3f);
        Debug.Log("masak adonan");
        gameManager.isCooked = true;
        spriteRenderer.sprite = adonanMatang;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.isCooked == true)
        {
            if (collision.tag == "Choco")
            {
                gameManager.chocoQty -= 1;
                gameManager.isChoco = true;
                spriteRenderer.sprite = coklat;

                Debug.Log("The object is choco");
            }

            if (collision.tag == "Nut")
            {
                gameManager.nutQty -= 1;
                gameManager.isNut = true;
                spriteRenderer.sprite = kacang;

                Debug.Log("The object is nut");
            }

            if (collision.tag == "Keju")
            {
                gameManager.kejuQty -= 1;
                gameManager.isKeju = true;
                spriteRenderer.sprite = keju;

                Debug.Log("The object is keju");
            }
        }

        //if (collision.tag == "Kemas")
        //{
        //    Instantiate(prefabTB, tempatTB.transform);
        //    gameManager.isButter = false;
        //    gameManager.isChoco = false;
        //    gameManager.isNut = false;
        //    gameManager.isKeju = false;
        //    //gameManager.isButter = false;
        //    //gameManager.isButter = false;
        //}
    }
}
