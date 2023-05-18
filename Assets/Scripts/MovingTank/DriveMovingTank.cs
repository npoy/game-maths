using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class DriveMovingTank : MonoBehaviour
{
    Vector2 Up = new Vector2(0, 1);
    Vector2 Right = new Vector2(1, 0);
    float speed = 0.2f;

    void Update()
    {
        Vector3 position = this.transform.position;

        if (Input.GetKey(KeyCode.UpArrow)) {
            position.x += Up.x * speed;
            position.y += Up.y * speed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            position.x += -Up.x * speed;
            position.y += -Up.y * speed;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            position.x += -Right.x * speed;
            position.y += -Right.y * speed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += Right.x * speed;
            position.y += Right.y * speed;
        }
       
        this.transform.position = position;
    }
}