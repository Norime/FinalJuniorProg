using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public void SpawnCat()
    {
        float RandomX = Random.Range(-xSpawnRange, xSpawnRange);
        float RandomZ = Random.Range(-zSpawnRange, zSpawnRange);
        SpawnAnimal(RandomX, RandomZ, Cats);
    }
}
