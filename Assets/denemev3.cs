    using System.Net.NetworkInformation;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class ben2 : MonoBehaviour
{
    float cubesize = 1.0f;
    public Transform pos1;
    public Transform pos2;

    private Vector3 origin;
    private Vector3 cross;
    private void Start()
    {
        


    }


    void Update()
    {
        Vector3 p_front = pos1.position - pos1.forward * cubesize / 2;
        Vector3 e_back = pos2.position - pos2.forward * cubesize / 2;
        Vector3 e_right = pos2.position + pos2.right * cubesize / 2;

        Vector3 cross = Vector3.Cross(e_back, e_right);

        transform.LookAt(2 * transform.position - pos1.position); 
    }
}