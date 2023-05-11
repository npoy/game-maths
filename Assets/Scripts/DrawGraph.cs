using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    public int size = 20;
    public int xMax = 200;
    public int yMax = 200;

    Coords startPointXAxis;
    Coords endPointXAxis;

    Coords startPointYAxis;
    Coords endPointYAxis;

    // Start is called before the first frame update
    void Start()
    {
        Coords startPointXAxis = new Coords(xMax, 0);
        Coords endPointXAxis = new Coords(-xMax, 0);

        Coords startPointYAxis = new Coords(0, yMax);
        Coords endPointYAxis = new Coords(0, -yMax);
        
        // x axis
        Coords.DrawLine(startPointXAxis, endPointXAxis, 1, Color.red);
        // y axis
        Coords.DrawLine(startPointYAxis, endPointYAxis, 1, Color.green);

        int xOffSet = (int)(xMax/(float)size);
        for (int x = -xOffSet*size; x <= xOffSet*size; x+= size)
        {
            Coords.DrawLine(new Coords(x, -yMax), new Coords(x, yMax), 0.5f, Color.white);
        }

        int yOffSet = (int)(yMax/(float)size);
        for (int y = -yOffSet*size; y <= yOffSet*size; y+= size)
        {
            Coords.DrawLine(new Coords(-xMax, y), new Coords(xMax, y), 0.5f, Color.white);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
