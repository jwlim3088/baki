using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody rb;
    float speed = 0.3f;
    float rotateSpeed = 0.3f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 getVel = new Vector3(xMove, 0, zMove) * speed;
        rb.velocity = getVel;

        if (!(xMove == 0 && zMove == 0))
        {
            transform.position += getVel * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(getVel), Time.deltaTime + rotateSpeed);
        }

    }

}

//public float Speed = 2.0f;

//public float rotateSpeed = 2.0f;

//float h, v;

//void FixedUpdate()
//{
//    h = Input.GetAxis("Horizontal");
//    v = Input.GetAxis("Vertical");

//    Vector3 dir = new Vector3(h, 0, v);

//    if (!(h == 0 && v == 0))
//    {
//        transform.position += dir * Speed * Time.deltaTime;
//        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime + rotateSpeed);
//    }
//}