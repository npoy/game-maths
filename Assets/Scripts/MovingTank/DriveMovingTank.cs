using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class DriveMovingTank : MonoBehaviour
{
    // Vector2 Up = new Vector2(0, 1);
    // Vector2 Right = new Vector2(1, 0);
    float speed = 5;
    public GameObject fuel;
    Vector3 direction;
    float stoppingDistance = 0.1f;

    void Start() {
        direction = fuel.transform.position - this.transform.position;
        // Debug.Log("Tank: " + this.name + ", direction: " + direction);
        CoordsMovingTank dirNormal = HolisticMath.GetNormal(new CoordsMovingTank(direction));
        direction = dirNormal.ToVector();
        // Debug.Log("Tank: " + this.name + ", normal: " + direction);
        float angle = HolisticMath.Angle(new CoordsMovingTank(0, 1, 0), new CoordsMovingTank(direction));

        bool clockwise = false;
        if (HolisticMath.Cross(new CoordsMovingTank(this.transform.up), dirNormal).z < 0) clockwise = true;
        CoordsMovingTank newDir = HolisticMath.Rotate(new CoordsMovingTank(this.transform.up), angle, clockwise);
        this.transform.up = new Vector3(newDir.x, newDir.y, newDir.z);
    }

    void Update()
    {
        if (HolisticMath.Distance(new CoordsMovingTank(this.transform.position), new CoordsMovingTank(fuel.transform.position)) > stoppingDistance) {
        // if (Vector3.Distance(this.transform.position, fuel.transform.position) > stoppingDistance) {
            // Vector3 direction = direction = fuel.transform.position - this.transform.position; // For slowness at the end of the movement
            Vector3 positionDiff = direction * speed * Time.deltaTime;
            // Debug.Log(this.name + " movement: " + positionDiff); // This is to have the same lenght on both so we can calculate. It's not the real distance, it's the vector normal
            this.transform.position += positionDiff;
        }

        /** ArrowKeys logic + Vectors Sum

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
        **/
    }
}