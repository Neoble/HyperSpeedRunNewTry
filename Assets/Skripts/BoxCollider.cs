using UnityEngine;
using System.Collections;

public class BoxCollider : MotherCollider
{
    public Vector3D BottomLeftFront { get { return new Vector3D(Left, Bottom, Front); } }
    public Vector3D BottomLeftBack { get { return new Vector3D(Left, Bottom, Back); } }
    public Vector3D BottomRightFront { get { return new Vector3D(Right, Bottom, Front); } }
    public Vector3D BottomRightBack { get { return new Vector3D(Right, Bottom, Back); } }
    public Vector3D TopLeftFront { get { return new Vector3D(Left, Top, Front); } }
    public Vector3D TopLeftBack { get { return new Vector3D(Left, Top, Back); } }
    public Vector3D TopRightFront { get { return new Vector3D(Right, Top, Front); } }
    public Vector3D TopRightBack { get { return new Vector3D(Right, Top, Back); } }
    public Vector3D BoxSize;
    public float Left { get { return Center.x - BoxSize.x / 2; } }
    public float Right { get { return Center.x + BoxSize.x / 2; } }
    public float Top { get { return Center.y + BoxSize.y / 2; } }
    public float Bottom { get { return Center.y - BoxSize.y / 2; } }
    public float Front { get { return Center.z - BoxSize.z / 2; } }
    public float Back { get { return Center.z + BoxSize.z / 2; } }
    public float WorldLeft { get{ return transform.position.x + Left; } }
    public float WorldRight { get{ return transform.position.x + Right; } }
    public float WorldTop { get{ return transform.position.y + Top; } }
    public float WorldBottom { get{ return transform.position.y + Bottom; } }
    public float WorldFront { get{ return transform.position.z + Front; } }
    public float WorldBack { get{ return transform.position.z + Back; } }

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawCube(WorldCenter, BoxSize);
    //}

}
