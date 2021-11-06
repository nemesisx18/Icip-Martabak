using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCustomer : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float maxWalk;
    public float walkingDirection = 1.0f;
    float originalY;

    Vector2 walkAmount;

    // Start is called before the first frame update
    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        walkAmount.y = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection < 0.0f && transform.position.y <= originalY + maxWalk)
        {
            walkingDirection = 0f;
        }
        
        transform.Translate(walkAmount);
    }

}
