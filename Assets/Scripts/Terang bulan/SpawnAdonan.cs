using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdonan : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public SpriteRenderer spriteRenderer;
    public Sprite coklat;
    public Sprite kacang;
    public Sprite keju;

    public GameObject chaCha;
    public GameObject matcha;
    public GameObject strawberry;
    public GameObject corn;

    public Sprite coklatKacang;
    public Sprite coklatKeju;
    public Sprite kacangKeju;
    public Sprite spesial;

    void Update()
    {
        if (gameManager.isChoco)
            spriteRenderer.sprite = coklat;
        if (gameManager.isNut)
            spriteRenderer.sprite = kacang;
        if (gameManager.isKeju)
            spriteRenderer.sprite = keju;
        if (gameManager.isChaCha)
            chaCha.SetActive(true);
        if (gameManager.isMatcha)
            matcha.SetActive(true);
        if (gameManager.isStrawberry)
            strawberry.SetActive(true);
        if (gameManager.isCorn)
            corn.SetActive(true);

        if (gameManager.isChoco && gameManager.isNut)
            spriteRenderer.sprite = coklatKacang;
        if (gameManager.isChoco && gameManager.isKeju)
            spriteRenderer.sprite = coklatKeju;
        if (gameManager.isNut && gameManager.isKeju)
            spriteRenderer.sprite = kacangKeju;
        if (gameManager.isChaCha && gameManager.isMatcha && gameManager.isStrawberry && gameManager.isCorn)
            spriteRenderer.sprite = spesial;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.isCooked == true)
        {
            if (collision.tag == "Choco")
            {
                gameManager.chocoQty -= 1;
                gameManager.isChoco = true;

                Debug.Log("The object is choco");
            }

            if (collision.tag == "Nut")
            {
                gameManager.nutQty -= 1;
                gameManager.isNut = true;

                Debug.Log("The object is nut");
            }

            if (collision.tag == "Keju")
            {
                gameManager.kejuQty -= 1;
                gameManager.isKeju = true;

                Debug.Log("The object is keju");
            }

            if(collision.tag == "ChaCha")
            {
                gameManager.chaChaQty -= 1;
                gameManager.isChaCha = true;
            }

            if (collision.tag == "Matcha")
            {
                gameManager.matchaQty -= 1;
                gameManager.isMatcha = true;
            }

            if (collision.tag == "Strawberry")
            {
                gameManager.strawberryQty -= 1;
                gameManager.isStrawberry = true;
            }

            if (collision.tag == "Corn")
            {
                gameManager.cornQty -= 1;
                gameManager.isCorn = true;
            }
        }
    }
}
