using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deneme : MonoBehaviour
{


    public float rotationSpeed;
    public float rotationDistance;
    public float dashSpeed;
    public float dashTime;
    public float speed;
    public float attackDelay;
    public float attack1Damage;
    public float attack2Damage;
    public GameObject pos1;
    Vector3 axis = new Vector3(0f, 0f, 1f);
    Transform player;
    float lastAttackTime;
    //bool isDashing = false;
    void Start()
    {
        player = pos1.transform;
    }
    void Update()
    {
        transform.RotateAround(player.position, axis, rotationSpeed * Time.deltaTime * 10f);
        transform.rotation = Quaternion.identity;
    }
}
