using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempatSampah : MonoBehaviour
{
    public GameObject[] topping;

    private AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TB_Coklat" || collision.tag == "TB_Kacang" || collision.tag == "TB_Keju" || 
            collision.tag == "TB_KacKej" || collision.tag == "TB_CokKac" || collision.tag == "TB_CokKej")
        {
            Destroy(collision.gameObject);
            source.Play();
            topping[0].SetActive(false);
            topping[1].SetActive(false);
            topping[2].SetActive(false);
            topping[3].SetActive(false);
            topping[4].SetActive(false);
            topping[5].SetActive(false);
        }
    }
}
