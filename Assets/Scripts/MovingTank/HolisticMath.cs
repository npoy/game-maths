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
}
