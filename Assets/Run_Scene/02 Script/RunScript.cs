using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour
{
    public float playerSpeed = 5; // �÷��̾� ���ǵ�
    private Vector3 startPlayerPosition; // �����Ҷ��� �÷��̾� ��ġ ����

    private Vector3 wallCollisionPositon;
    private Rigidbody rg;
    void Start()
    {
        startPlayerPosition = this.transform.localPosition; // �����Ҷ� �÷��̾� ��ġ ���� ������ ���� 
        rg = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        // ���α׷��� �ð� �帧�� ���� �� 
        if (Time.timeScale == 1)
        {
            // ���� Ű�� ������ ���� !!
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.localPosition += new Vector3(-0.1f, 0, 0) * playerSpeed * Time.deltaTime; // ��������(x ����) -0.1f * 5 * �ð��帧 ��ŭ ��� ������
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, -90f, 0)); // �÷��̾� ȸ�� ���� y������ -90��ŭ ���� 
            }
            // ������
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.localPosition += new Vector3(0.1f, 0, 0) * playerSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 90f, 0));
            }
            // ��
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.localPosition += new Vector3(0, 0, 0.1f) * playerSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            // �Ʒ�
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.localPosition += new Vector3(0f, 0, -0.1f) * playerSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 180f, 0));
            }
            // �밢�� ���� �� ����
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, -45f, 0));
            }
            // �밢�� ���� �Ʒ� ����
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 225f, 0));
            }
            // �밢�� ������ �� ����
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 45f, 0));
            }
            // �밢�� ������ �Ʒ� ����
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 135f, 0));
            }
        }
        /*
        // �ӵ��� �̿��Ͽ� �̵��ϱ�
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 getVe1 = new Vector3(xMove, 0, zMove) * playerSpeed;
        rg.velocity = getVe1;
        /**/
    }

    /// <summary>
    /// �浹ü �̺�Ʈ �Լ�
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹�� ������Ʈ�� �̸��� Cube(Clone) �̸�?
        if (other.gameObject.name == "Cube(Clone)")
        {
            // ����
            // �浹�� ������Ʈ�� �����Ѵ�.
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            wallCollisionPositon = transform.position;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            transform.position = wallCollisionPositon;
        }
    }
}

