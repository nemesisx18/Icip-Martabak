using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMartabakku : MonoBehaviour
{
    public GameObject coklat;
    public GameObject keju;
    public GameObject kacang;
    public GameObject coklatKacang;
    public GameObject coklatKeju;
    public GameObject kacangKeju;
    public GameObject spesial;
    public GameObject menuMartabak;

    public AudioSource source;
    public AudioClip clip;

    public void ReturnHome()
    {
        //SceneManager.LoadScene("MainMenu");
        menuMartabak.SetActive(false);
        source.PlayOneShot(clip);
    }

    public void Coklat()
    {
        coklat.SetActive(true);
        keju.SetActive(false);
        kacang.SetActive(false);
        coklatKacang.SetActive(false);
        coklatKeju.SetActive(false);
        kacangKeju.SetActive(false);
        spesial.SetActive(false);

        source.PlayOneShot(clip);
    }

    public void Keju()
    {
        coklat.SetActive(false);
        keju.SetActive(true);
        kacang.SetActive(false);
        coklatKacang.SetActive(false);
        coklatKeju.SetActive(false);
        kacangKeju.SetActive(false);
        spesial.SetActive(false);

        source.PlayOneShot(clip);
    }

    public void Kacang()
    {
        coklat.SetActive(false);
        keju.SetActive(false);
        kacang.SetActive(true);
        coklatKacang.SetActive(false);
        coklatKeju.SetActive(false);
        kacangKeju.SetActive(false);
        spesial.SetActive(false);

        source.PlayOneShot(clip);
    }

    public void CoklatKacang()
    {
        coklat.SetActive(false);
        keju.SetActive(false);
        kacang.SetActive(false);
        coklatKacang.SetActive(true);
        coklatKeju.SetActive(false);
        kacangKeju.SetActive(false);
        spesial.SetActive(false);

        source.PlayOneShot(clip);
    }

    public void CoklatKeju()
    {
        coklat.SetActive(false);
        keju.SetActive(false);
        kacang.SetActive(false);
        coklatKacang.SetActive(false);
        coklatKeju.SetActive(true);
        kacangKeju.SetActive(false);
        spesial.SetActive(false);

        source.PlayOneShot(clip);
    }

    public void KacangKeju()
    {
        coklat.SetActive(false);
        keju.SetActive(false);
        kacang.SetActive(false);
        coklatKacang.SetActive(false);
        coklatKeju.SetActive(false);
        kacangKeju.SetActive(true);
        spesial.SetActive(false);

        source.PlayOneShot(clip);
    }

    public void Spesial()
    {
        coklat.SetActive(false);
        keju.SetActive(false);
        kacang.SetActive(false);
        coklatKacang.SetActive(false);
        coklatKeju.SetActive(false);
        kacangKeju.SetActive(false);
        spesial.SetActive(true);

        source.PlayOneShot(clip);
    }
}
