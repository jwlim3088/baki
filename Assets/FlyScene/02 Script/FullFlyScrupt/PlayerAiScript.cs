using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiScript : MonoBehaviour
{
    public GameObject sphereObj; //ã�� ���Ǿ� ������Ʈ
    public Vector3 vector3;
    public float playerSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        sphereObj = GameObject.FindWithTag("Sphere"); //���Ǿ� ������Ʈ ã�±��

        vector3 = sphereObj.transform.position - transform.position; //���Ǿ ���� ���⺤��
        vector3 = vector3.normalized;
        transform.rotation = Quaternion.LookRotation(vector3); //���⺤�͸� �̿��Ͽ� ȸ�������� ����
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += vector3 * playerSpeed * Time.deltaTime; // ����
    }
}
