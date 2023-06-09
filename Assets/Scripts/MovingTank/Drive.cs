﻿using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

namespace MovingTank
{
    public class Drive : MonoBehaviour
    {
        // Vector2 Up = new Vector2(0, 1);
        // Vector2 Right = new Vector2(1, 0);
        float speed = 5;
        public GameObject fuel;
        Vector3 direction;
        float stoppingDistance = 0.1f;

        void Start() {
            direction = fuel.transform.position - this.transform.position;
            Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));
            direction = dirNormal.ToVector();

            this.transform.up = HolisticMath.LookAt2D(new Coords(this.transform.up), new Coords(this.transform.position), new Coords(fuel.transform.position)).ToVector();
        }

        void Update()
        {
            if (HolisticMath.Distance(new Coords(this.transform.position), new Coords(fuel.transform.position)) > stoppingDistance) {
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
}