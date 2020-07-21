using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PerisableObject {

    public int ShapeID
    {
        get
        {
            return shapeID;
        }
        set
        {
            if (shapeID == int.MinValue && value != int.MinValue)
                shapeID = value;
            else
                Debug.LogError("Invalid operation: Not allowed to change shapeID.");
        }
    }

    private int shapeID = int.MinValue;
}
