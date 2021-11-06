using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdonan : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

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
        }
    }
}
