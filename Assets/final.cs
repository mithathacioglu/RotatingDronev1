using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UIElements;
using JetBrains.Annotations;
using System.Drawing;
using UnityEngine.Scripting;
using System.Reflection;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ExampleClass11 : MonoBehaviour
{
    //public Transform player;
    //public Transform enemy;
    //public Transform drone;
    //Vector3 crossProduct;
    public Transform pos1;
    public Transform pos2;
    public Transform drone;
    //public LineRenderer line1;
    //public LineRenderer line2;
    float cubesize = 1.0f;
    public Plane plane;
    private float radius=5;
    

    public Vector3 ilkVektor;
    public Vector3 ikinciVektor;


    static void DrawPlaneAtPoint(Plane plane, Vector3 center, float size,UnityEngine.Color color, float duration, bool depthTest)
    {
        var basis = Quaternion.LookRotation(plane.normal);
        var scale = Vector3.one * size / 10f;

        var right = Vector3.Scale(basis * Vector3.right, scale);
        var up = Vector3.Scale(basis * Vector3.up, scale);

        for (int i = -5; i <= 5; i++)
        {
            Debug.DrawLine(center + right * i - up * 5, center + right * i + up * 5, color, duration, depthTest);
            Debug.DrawLine(center + up * i - right * 5, center + up * i + right * 5, color, duration, depthTest);
        }
    }
    private void Start()
    {
        //line1.positionCount = 2;
        //line1.positionCount = 2;
        ApplyRadius();

        
        ilkVektor = pos1.position + pos1.forward * cubesize / 2;    
        ikinciVektor = pos2.position - pos2.forward * cubesize / 2;
        Vector3 PlaneVektor1 = ikinciVektor - ilkVektor;
        Vector3 PlaneVektor3 = pos1.position + pos1.right * cubesize / 2 + pos1.forward * cubesize / 2 - ilkVektor;
        Vector3 PlaneNormal = Vector3.Cross(PlaneVektor1, PlaneVektor3);
        transform.RotateAround(pos1.transform.position, PlaneNormal, 100 * Time.deltaTime);
         
        // Vector3 nv =- (ilkVektor- ikinciVektor)*20;
        //print( nv);
        //Debug.DrawLine(ilkVektor, ikinciVektor, UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(pos1.position + pos1.right * cubesize / 2 + pos1.forward * cubesize / 2, ilkVektor, UnityEngine.Color.blue, Mathf.Infinity);

        //Debug.DrawLine(ilkVektor, PlaneVektor1, UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(ilkVektor, Vector3.Cross(PlaneVektor1, PlaneVektor3), UnityEngine.Color.green, Mathf.Infinity);

        //Debug.DrawLine(ilkVektor, PlaneVektor3, UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(pos1.position + pos1.right * cubesize / 2 + pos1.forward * cubesize / 2, ilkVektor, UnityEngine.Color.blue, Mathf.Infinity);

        //Debug.DrawLine(pos2.position, tersCrossProduct, Color.yellow, Mathf.Infinity);
        plane = new Plane(PlaneNormal, (pos1.position + pos2.position) / 2);
        DrawPlaneAtPoint(plane, (pos1.position + pos2.position) / 2, 10, UnityEngine.Color.black, 102, true);

        print(PlaneVektor1);
        print(PlaneVektor3);
        print(PlaneNormal);

        //DrawRay ile Scene panelinde görselleştirelim

        //line1.SetPosition(0, ilkVektor);
        //    line1.SetPosition(1, ikinciVektor);
        //    line1.SetPosition(0, pos1.position);
        //    line1.SetPosition(1, crossProduct);



    }

    // public Quaternion rotation = Quaternion.identity;
    void Update()
    {
     

        System.Random rnd = new System.Random();
        float num = rnd.Next(0,10);
        print(num);
        pos1.position = pos1.position + new Vector3(5, 0, -5)*0.5f*Time.deltaTime;
       

        ApplyRadius();
       

        
        Vector3 ilkVektor = pos1.position + pos1.forward * cubesize / 2;
        Vector3 ikinciVektor = pos2.position - pos2.forward * cubesize / 2;
        Vector3 PlaneVektor1 = ikinciVektor - ilkVektor;
        Vector3 PlaneVektor3 = pos1.position + pos1.right * cubesize / 2 + pos1.forward * cubesize / 2 - ilkVektor;
        Vector3 PlaneNormal = Vector3.Cross(PlaneVektor1, PlaneVektor3);
         drone.position = drone.position + new Vector3(5, 0, -5) * 0.5f * Time.deltaTime;
        drone.transform.RotateAround(pos1.position, -PlaneNormal.normalized, 500 * Time.deltaTime);
        //Debug.DrawLine(ilkVektor, ikinciVektor, UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(0, 0, 0), UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(pos1.position + pos1.right * cubesize / 2 + pos1.forward * cubesize / 2, ilkVektor, UnityEngine.Color.blue, Mathf.Infinity);
        
        //Debug.DrawLine(ilkVektor, PlaneVektor1, UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(ilkVektor, Vector3.Cross(PlaneVektor1, PlaneVektor3), UnityEngine.Color.green, Mathf.Infinity);

        //Debug.DrawLine(ilkVektor, PlaneVektor3, UnityEngine.Color.red, Mathf.Infinity);
        //Debug.DrawLine(pos1.position + pos1.right * cubesize / 2 + pos1.forward * cubesize / 2, ilkVektor, UnityEngine.Color.blue, Mathf.Infinity);



    }

    private void ApplyRadius()
    {
         
         
        var direction = (drone.transform.position - pos1.transform.position).normalized;

        
        drone.transform.position = pos1.transform.position + direction * radius;

       
    }
  

}