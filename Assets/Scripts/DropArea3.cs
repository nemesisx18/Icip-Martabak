using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea3 : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player masuk area 3");
        }
    }
}
