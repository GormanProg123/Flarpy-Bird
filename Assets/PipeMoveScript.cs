using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 7;
    public float deadZone = -38;
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
