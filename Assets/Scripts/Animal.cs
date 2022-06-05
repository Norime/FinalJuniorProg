using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : CapacityManager
{
    private float startDelay = 1.0f;
    private float spawnEnemyDelay = 10.0f;
    public float xSpawnRange = 10;
    public float zSpawnRange = 10;
    public GameObject[] Dogs;
    public GameObject[] Cats;
    public void Start()
    {
        InvokeRepeating("SpawnDog", startDelay, spawnEnemyDelay);
        InvokeRepeating("SpawnCat", startDelay, spawnEnemyDelay);
    }
    public void SpawnDog()
    {

    }
    public void SpawnCat()
    {

    }

    public void SpawnAnimal(float posX, float posZ, GameObject animal)
    {
        Vector3 spawnPos = new Vector3(posX, 1, posZ);
        Instantiate(animal, spawnPos, animal.gameObject.transform.rotation);
    }
    public void SpawnAnimal(float posX, float posZ, GameObject[] animals)
    {
        int randomIndex = Random.Range(0, Dogs.Length);
        Vector3 spawnPos = new Vector3(posX, 1, posZ);
        Instantiate(animals[randomIndex], spawnPos, animals[randomIndex].gameObject.transform.rotation);
    }
}
