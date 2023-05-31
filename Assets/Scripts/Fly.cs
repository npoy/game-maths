using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float translateX = Input.GetAxis("Horizontal") * speed; 
        float translateY = Input.GetAxis("VerticalY") * speed; 
        float translateZ = Input.GetAxis("Vertical") * speed;

        transform.Translate(translateX, translateY, translateZ);
    }
}
