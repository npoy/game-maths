using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath : MonoBehaviour
{
    static public CoordsMovingTank GetNormal(CoordsMovingTank vector) {
        float length = Distance(new CoordsMovingTank(0, 0, 0), vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;
        
        return vector;
    }

    static public float Distance(CoordsMovingTank point1, CoordsMovingTank point2) {
        float diffSquared = Square(point1.x - point2.x) + Square(point1.y - point2.y) + Square(point1.z - point2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float Square(float value) {
        return value * value;
    }

    static public float Dot(CoordsMovingTank vector1, CoordsMovingTank vector2) {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public float Angle(CoordsMovingTank vector1, CoordsMovingTank vector2) {
        float dotDivide = Dot(vector1, vector2) / (Distance(new CoordsMovingTank(0, 0, 0), vector1) * Distance(new CoordsMovingTank(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); // radians. For degrees * 180/Mathf.PI;
    }

    static public CoordsMovingTank LookAt2D(CoordsMovingTank forwardVector, CoordsMovingTank position, CoordsMovingTank focusPoint) {
        CoordsMovingTank direction = new CoordsMovingTank(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
        float angle = HolisticMath.Angle(forwardVector, direction);
        bool clockwise = false;
        if (HolisticMath.Cross(forwardVector, direction).z < 0) clockwise = true;
        CoordsMovingTank newDirection = HolisticMath.Rotate(forwardVector, angle, clockwise);
        return newDirection;
    }

    static public CoordsMovingTank Rotate(CoordsMovingTank vector, float angle, bool clockwise) { // in radians
        if (clockwise)
            angle = 2 * Mathf.PI - angle; // radians - (doing a whole circle anti-clockwise, 360 - angle but in radians)
        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new CoordsMovingTank(xVal, yVal, 0);
    }

    static public CoordsMovingTank Translate(CoordsMovingTank position, CoordsMovingTank facing, CoordsMovingTank vector) {
        if (HolisticMath.Distance(new CoordsMovingTank(0, 0, 0), vector) <= 0) return position;
        float angle = HolisticMath.Angle(vector, facing);
        float worldAngle = HolisticMath.Angle(vector, new CoordsMovingTank(0, 1, 0));
        bool clockwise = false;
        if (HolisticMath.Cross(vector, facing).z < 0) clockwise = true;

        vector = HolisticMath.Rotate(vector, angle + worldAngle, clockwise);

        float xVal = position.x + vector.x;
        float yVal = position.y + vector.y;
        float zVal = position.z + vector.z;
        return new CoordsMovingTank(xVal, yVal, zVal);
    }

    static public CoordsMovingTank Cross(CoordsMovingTank vector1, CoordsMovingTank vector2) {
        float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        float zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        CoordsMovingTank crossProduct = new CoordsMovingTank(xMult, yMult, zMult);
        return crossProduct;
    }
}
