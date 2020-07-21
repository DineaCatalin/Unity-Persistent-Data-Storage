using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShapeFactory : ScriptableObject {

    [SerializeField]
    Shape[] m_Shapes;

    public Shape Get(int shapeID)
    {
        Shape shape = Instantiate(m_Shapes[shapeID]);
        shape.ShapeID = shapeID;
        return shape;
    }

  
}
