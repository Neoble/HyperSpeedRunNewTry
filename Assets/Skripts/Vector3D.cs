using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct Vector3D
{
    public float x, y, z;

    public Vector3D(float x,float y,float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public float Magnitude()
    {
        return Mathf.Sqrt(x * x + y * y + z * z);
    }
    public static Vector3D operator -(Vector3D x,Vector3D y)
    {
        return new Vector3D(x.x - y.x, x.y - y.y, x.z - y.z);
    }

    public Vector3D Translate(Vector3D end)
    {
        return new Vector3D(end.x,end.y,end.z);        
    }
    public static implicit operator Vector3(Vector3D m)
    {
        return new Vector3(m.x, m.y, m.z);
    }
    public static implicit operator Vector3D(Vector3 m)
    {
        return new Vector3D(m.x, m.y, m.z);
    }

    public static Vector3D Position(GameObject m)
    {
        return new Vector3D(m.transform.position.x, m.transform.position.y, m.transform.position.z);
    }

    public static Vector3D Falling(GameObject m,float fallingSpeed)
    {
 
        return new Vector3D(m.transform.position.x, m.transform.position.y+fallingSpeed * Time.deltaTime, m.transform.position.z);
    }

}

