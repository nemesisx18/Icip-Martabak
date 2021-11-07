using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoin3 : MonoBehaviour
{
    [SerializeField] private GameManager3 gameManager;

    public SpriteRenderer spriteRenderer;
    public Sprite adonanMatang;
    public Sprite adonanMasak;

    public GameObject adonanTB;
    public GameObject timer;
    public Transform destTB;
    public Transform defaultTB;

    private AudioSource source;
    public Animator anim;
    public AudioClip masak;
    public AudioClip matang;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    IEnumerator CookDough()
    {
        spriteRenderer.sprite = adonanMasak;
        gameManager.isCooked = false;
        adonanTB.transform.position = defaultTB.transform.position;
        anim.SetBool("isGerak", false);
        source.clip = masak;
        timer.SetActive(true);
        source.Play();

        yield return new WaitForSeconds(3f);
        Debug.Log("masak adonan");
        gameManager.isCooked = true;
        spriteRenderer.sprite = adonanMatang;
        adonanTB.transform.position = destTB.transform.position;
        anim.SetBool("isGerak", true);
        source.clip = matang;
        timer.SetActive(false);
        source.Play();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mentega")
        {
            StartCoroutine(CookDough());
            gameManager.butterQty -= 1;
            gameManager.isButter = true;

            Debug.Log("The object is mentega");
        }
    }
}
