using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScrupt : MonoBehaviour
{
    public GameObject playerObj;
    public float playerSpawnCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoPlayerSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoPlayerSpawn()
    {
        Instantiate(playerObj, transform.position, transform.rotation);
            yield return new WaitForSeconds(playerSpawnCounter);
    }
}
