using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class CameraScript : MonoBehaviour
{



    public GameObject player;



    
    void Start()
    {

    }


    void Update()
    {
        transform.position = player.transform.position + new Vector3(1, 5.5f - 3);  
    }

}



