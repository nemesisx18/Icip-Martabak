using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeBar : MonoBehaviour
{
    public Slider countdownBar;

    public float timer = 20;
    public bool cantOrder;

    public CustSpawn custSpawn;

    Vector2 walkAmount;

    public void SetManager(CustSpawn _custSpawn)
    {
        custSpawn = _custSpawn;
    }

    void Start()
    {
        //Set the max value to the refill time
        countdownBar.maxValue = timer;
        cantOrder = false;
    }

    private void Update()
    {
        StartCoroutine(DelaySpawn());
        
        if (countdownBar.value >= timer)
        {
            StartCoroutine(EndOrder());
        }
    }

    public void LeftArea()
    {
        walkAmount.x = 1f * 3f * Time.deltaTime;
        transform.Translate(walkAmount);
    }

    public IEnumerator EndOrder()
    {
        LeftArea();
        cantOrder = true;

        yield return new WaitForSeconds(1f);
        custSpawn.custQty -= 1;
        custSpawn.isSpawned = false;
        Destroy(this.gameObject);
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSecondsRealtime(3f);
        countdownBar.value += Time.deltaTime;
    }
}
