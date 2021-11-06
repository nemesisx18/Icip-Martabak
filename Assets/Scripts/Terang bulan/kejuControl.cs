using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kejuControl : MonoBehaviour
{
    public GameObject prefabKeju;
    public GameObject baseKeju;

    public Transform spawnTB;

    void OnMouseDown()
    {
        //baseKeju.SetActive(false);
        
        Instantiate(prefabKeju, spawnTB.transform);

        Debug.Log("test");
    }
}
