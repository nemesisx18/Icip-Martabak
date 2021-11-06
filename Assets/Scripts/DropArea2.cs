using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea2 : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player masuk area 2");
        }
    }
}
