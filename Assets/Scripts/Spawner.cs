using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruits;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        var fruit = Random.Range(0, fruits.Count);
        Instantiate(fruits[fruit], transform.position, Quaternion.identity);
    }
}
