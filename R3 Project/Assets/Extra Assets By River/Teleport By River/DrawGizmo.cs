using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    public Color color;
    public float size;
    public enum Shape { Cube,Sphere}
    public Shape shape;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
       // Gizmos.matrix = this.transform.localToWorldMatrix;
        if (shape == Shape.Sphere) { Gizmos.DrawSphere(Vector3.zero, size * transform.localScale.x);}
        else if (shape == Shape.Cube) { Gizmos.DrawCube(transform.position + transform.GetComponent<BoxCollider>().center, new Vector3(transform.GetComponent<BoxCollider>().size.x * transform.localScale.x, transform.GetComponent<BoxCollider>().size.y * transform.localScale.y, transform.GetComponent<BoxCollider>().size.z * transform.localScale.z)); }
    }
}
