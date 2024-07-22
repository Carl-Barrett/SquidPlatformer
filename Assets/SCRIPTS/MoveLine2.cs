using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLine2 : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnFrequency = 1f;
    public float destroyDistance = 10f;
    public float moveSpeed = 2f;

    private float timeSinceLastSpawn = 0f;

    
    void Update()
    {
        
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnFrequency)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f;
        }

        
        foreach (Transform child in transform)
        {
            child.Translate(moveSpeed * Time.deltaTime, 0f, 0f);

            //Destroy when Its too far
            if (child.position.x <= transform.position.x - destroyDistance)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void SpawnObject()
    {
        GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        GameObject newObject = Instantiate(randomPrefab, transform.position, Quaternion.identity);
        newObject.transform.parent = transform;
    }
}
