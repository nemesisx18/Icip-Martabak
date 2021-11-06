using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;

    public Vector2 speed = new Vector2(50, 50);

    void FixedUpdate()
    {
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical;

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
