using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStage : MonoBehaviour
{
    public GameObject[] imageTutor;
    public GameObject exit;
    public GameObject tutorCanvas;
    public int currentImage;

    // Start is called before the first frame update
    void Start()
    {
        exit.SetActive(false);
        Time.timeScale = 0;
        
        for (int i = 0; i < imageTutor.Length; i++)
        {
            imageTutor[i].SetActive(false);

            currentImage = 0;
            imageTutor[0].SetActive(true);
        }
    }

    void Update()
    {
        if(currentImage >= 3)
        {
            exit.SetActive(true);
        }
    }

    public void NextImage()
    {
        imageTutor[currentImage].SetActive(false);

        if (currentImage >= imageTutor.Length - 1)
        {
            currentImage = 0;
            imageTutor[currentImage].SetActive(true);
            //Debug.Log ("Function Part 1");

        }
        else
        {
            currentImage++;
            imageTutor[currentImage].SetActive(true);
            //Debug.Log ("Function Part 2  array lenght = " + characterModels.Length.ToString());
        }
    }

    public void ExitTutor()
    {
        tutorCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
