using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public JoyStickValue value;
    public int speed;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(value.joyTouch * Time.deltaTime * speed);
    }
}
