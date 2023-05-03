using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitShiftingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string A = "110111";
        string B = "10001";
        string C = "1101";
        int aBits = Convert.ToInt32(A, 2);
        int bBits = Convert.ToInt32(B, 2);
        int cBits = Convert.ToInt32(C, 2);

        int packed = 0;

        packed = packed | (aBits << 26);
        packed = packed | (bBits << 21);
        packed = packed | (cBits << 17);

        Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));

        // -----------------------------------------------------

        A = "1111";
        B = "101";
        C = "11011";
        aBits = Convert.ToInt32(A, 2);
        bBits = Convert.ToInt32(B, 2);
        cBits = Convert.ToInt32(C, 2);

        packed = 0;

        packed = packed | (aBits << 28);
        packed = packed | (bBits << 25);
        packed = packed | (cBits << 20);

        Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));
    }
}
