using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour
{
    public float playerSpeed = 5; // 플레이어 스피드
    private Vector3 startPlayerPosition; // 시작할때의 플레이어 위치 변수

    private Vector3 wallCollisionPositon;
    private Rigidbody rg;
    void Start()
    {
        startPlayerPosition = this.transform.localPosition; // 시작할때 플레이어 위치 값을 변수에 저장 
        rg = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        // 프로그램의 시간 흐름이 있을 때 
        if (Time.timeScale == 1)
        {
            // 왼쪽 키를 누르는 동안 !!
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.localPosition += new Vector3(-0.1f, 0, 0) * playerSpeed * Time.deltaTime; // 왼쪽으로(x 방향) -0.1f * 5 * 시간흐름 만큼 계속 더해줌
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, -90f, 0)); // 플레이어 회전 각을 y축으로 -90만큼 지정 
            }
            // 오른쪽
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.localPosition += new Vector3(0.1f, 0, 0) * playerSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 90f, 0));
            }
            // 위
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.localPosition += new Vector3(0, 0, 0.1f) * playerSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            // 아래
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.localPosition += new Vector3(0f, 0, -0.1f) * playerSpeed * Time.deltaTime;
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 180f, 0));
            }
            // 대각선 왼쪽 위 방향
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, -45f, 0));
            }
            // 대각선 왼쪽 아래 방향
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 225f, 0));
            }
            // 대각선 오른쪽 위 방향
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 45f, 0));
            }
            // 대각선 오른쪽 아래 방향
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 135f, 0));
            }
        }
        /*
        // 속도를 이용하여 이동하기
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 getVe1 = new Vector3(xMove, 0, zMove) * playerSpeed;
        rg.velocity = getVe1;
        /**/
    }

    /// <summary>
    /// 충돌체 이벤트 함수
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌한 오브젝트의 이름이 Cube(Clone) 이면?
        if (other.gameObject.name == "Cube(Clone)")
        {
            // 실행
            // 충돌한 오브젝트를 삭제한다.
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

