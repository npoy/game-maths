using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public Text score;
    long dirtBB = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int r = 0; r < 8; r++)
            for (int c = 0; c < 8; c++) {
                int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                Vector3 pos = new Vector3(c, 0, r);
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = tile.tag + "_" + r + "_" + c;
                if (tile.tag == "Dirt") {
                    dirtBB = SetCellState(dirtBB, r, c);
                    PrintBB(tile.tag, dirtBB);
                }
            }
        // Debug.Log("dirtBB: " + dirtBB);
        // Debug.Log("dirtBB - 1: " + (dirtBB - 1));
        Debug.Log("Dirt cells = " + CellCount(dirtBB));
    }

    void PrintBB(string name, long BB) {
        Debug.Log(name + ": " + Convert.ToString(BB, 2).PadLeft(64, '0'));
    }

    long SetCellState(long bitboard, int row, int col) {
        long newBit = 1L << (row * 8 + col);
        return (bitboard |= newBit);
    }

    int CellCount(long bitboard) {
        int count = 0;
        long bb = bitboard;
        while (bb != 0) {
            // Debug.Log("bb: " + bb);
            // Debug.Log("bb^2: " + Convert.ToString(bb, 2).PadLeft(64, '0'));
            bb &= bb - 1;
            // Debug.Log("bb - 1: " + (bb - 1));
            // Debug.Log("bb-1^2: " + Convert.ToString((bb - 1), 2).PadLeft(64, '0'));
            // Debug.Log("bb &=: " + bb);
            count++;
        }
        return count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
