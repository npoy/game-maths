using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class DriveMovingTank : MonoBehaviour
{
    Vector2 Up = new Vector2(0, 0.1f);
    // Vector2 Down = new Vector2(0, -0.1f);
    Vector2 Left = new Vector2(-0.1f, 0);
    // Vector2 Right = new Vector2(0.1f, 0);

    void Update()
    {
        Vector3 position = this.transform.position;

        if (Input.GetKey(KeyCode.UpArrow)) {
            position.x += Up.x;
            position.y += Up.y;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            position.x += -Up.x;
            position.y += -Up.y;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            position.x += Left.x;
            position.y += Left.y;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += -Left.x;
            position.y += -Left.y;
        }
       
        this.transform.position = position;
    }
}