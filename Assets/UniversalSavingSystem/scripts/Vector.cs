using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vector
{
    public readonly float x, y, z;

    public Vector(float x, float y, float z)
    {
        this.x = x; 
        this.y = y; 
        this.z = z;
    }
}
