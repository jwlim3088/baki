using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiScript : MonoBehaviour
{
    public GameObject sphereObj; //찾을 스피어 오브젝트
    public Vector3 vector3;
    public float playerSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        sphereObj = GameObject.FindWithTag("Sphere"); //스피어 오브젝트 찾는기능

        vector3 = sphereObj.transform.position - transform.position; //스피어를 향한 방향벡터
        vector3 = vector3.normalized;
        transform.rotation = Quaternion.LookRotation(vector3); //방향벡터를 이용하여 회전값으로 변경
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += vector3 * playerSpeed * Time.deltaTime; // 앞쪽
    }
}
