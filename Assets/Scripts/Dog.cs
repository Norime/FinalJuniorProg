using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
   
    // Start is called before the first frame update
    public void SpawnDog()
    {
        float RandomX = Random.Range(-xSpawnRange, xSpawnRange);
        float RandomZ = Random.Range(-zSpawnRange, zSpawnRange);
        SpawnAnimal(RandomX, RandomZ, Dogs);
    }
}
