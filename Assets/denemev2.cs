using System.Net.NetworkInformation;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class ben : MonoBehaviour
{
    float cubesize = 1.0f;
    public Transform pos1;
    private Vector3 origin;
    private Vector3 cross;
    private void Start()
    {
         

        //cross = Vector3.Cross(ilkVektor, ikinciVektor);
        //Debug.DrawLine(pos2.position, ilkVektor, Color.red, Mathf.Infinity);
       // Debug.DrawLine(pos2.position, ikinciVektor, Color.blue, Mathf.Infinity);
       // Debug.DrawLine(pos2.position, cross, Color.green, Mathf.Infinity);
    }


    void Update()
    {
        Vector3 e_back = pos1.position - pos1.forward * cubesize / 2; 
         
        transform.LookAt(e_back);

        //Debug.DrawLine(pos2.position, cross, Color.green, Mathf.Infinity);

    }
}