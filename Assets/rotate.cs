using UnityEngine;

//Attach this script to a GameObject to rotate around the target position.
public class Example1 : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    public Transform pos1;
    public Transform pos2;
    float cubesize = 1.0f;

    void Update()
    {
        Vector3 ilkVektor = pos2.position + pos2.forward * cubesize / 2- pos2.position;
        Vector3 ikinciVektor = pos2.position + pos2.right * cubesize / 2- pos2.position;
        Vector3 crossProduct = Vector3.Cross(ilkVektor, ikinciVektor);
        Vector3 tersCrossProduct = Vector3.Cross(ikinciVektor, ilkVektor);
        transform.RotateAround(pos2.transform.position, crossProduct, 20 * Time.deltaTime);
        float distance = Vector3.Distance(pos1.transform.position, pos2.transform.position);
        print(distance);

    }
}