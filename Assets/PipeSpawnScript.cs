using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    public float minHeight = -3.0f; 
    public float maxHeight = 3.0f; 
    private float timer;

    private void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float randomHeight = Random.Range(minHeight, maxHeight); 
        Vector3 spawnPos = transform.position + new Vector3(0, randomHeight);
        GameObject newPipe = Instantiate(pipe, spawnPos, Quaternion.identity);
    }
}
