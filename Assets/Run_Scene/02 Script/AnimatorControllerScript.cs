using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerScript : MonoBehaviour
{
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow))) //�Ķ���� Run�� true�� ����
        {
            //�ִϸ����Ͱ� �޸���.
            myAnimator.SetBool("Run", true);

        }
        else
        {
            myAnimator.SetBool("Run", false);
        }
    }
}
