using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledTankDrive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // transform.Translate(0, translation, 0);
        transform.position = HolisticMath.Translate(new CoordsMovingTank(transform.position), new CoordsMovingTank(transform.up), new CoordsMovingTank(0, translation, 0)).ToVector();

        // transform.Rotate(0, 0, -rotation);
        transform.up = HolisticMath.Rotate(new CoordsMovingTank(transform.up), rotation * Mathf.Deg2Rad, true).ToVector();
    }
}
