using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource iyaGeh;
    public AudioClip clip;
    public AudioClip iyaSound;
    
    public GameObject popupSetting;
    public GameObject aboutSetting;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        iyaGeh = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        iyaGeh.clip = iyaSound;

        iyaGeh.Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        audioSource.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
        audioSource.Play();
    }

    public void SettingMenu()
    {
        popupSetting.SetActive(true);
        audioSource.Play();
    }

    public void AboutMenu()
    {
        aboutSetting.SetActive(true);
        audioSource.Play();
    }

    public void ExitSetting()
    {
        popupSetting.SetActive(false);
        audioSource.Play();
    }

    public void ExitAbout()
    {
        aboutSetting.SetActive(false);
        audioSource.Play();
    }

    public void GojekOrder()
    {
        Application.OpenURL("https://gofood.co.id/english/bandar-lampung/restaurant/martabak-bangka-anugrah-koga-za-pagar-alam-0bfeb9d3-cd37-4139-bcc2-78fbc6f90f05");
        audioSource.Play();
    }

    public void GrabOrder()
    {
        Application.OpenURL("https://food.grab.com/id/en/restaurant/martabak-bangka-anugrah-koga-gedong-meneng-delivery/6-C2MEATMFCFAYNT");
        audioSource.Play();
    }

    public void Openmap()
    {
        Application.OpenURL("https://goo.gl/maps/irNqfNPaDjyUJT8u6");
        audioSource.Play();
    }
}
