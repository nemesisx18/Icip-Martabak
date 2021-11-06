using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidManager : MonoBehaviour
{
    public VideoPlayer vp;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(EndVideo());
    }

    IEnumerator EndVideo()
    {
        yield return new WaitForSeconds(6);
        vp.Stop();
    }
}
