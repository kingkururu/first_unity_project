using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public Color gizmoColor = new Color(255, 255, 255, 1.0f);
    public bool drawCircle = false;
    public float radius = 1f;
    public bool drawRectangle = false;
    
    void OnDrawGizmos() 
    {
        Gizmos.color = gizmoColor;
        
        if (drawRectangle) 
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        } 
        else if (drawCircle) 
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        
    }
}