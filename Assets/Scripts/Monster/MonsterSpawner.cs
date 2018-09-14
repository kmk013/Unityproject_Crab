using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    public float startSpawnTime = 0f;
    public float spawnInterval;
    public List<GameObject> monsters = new List<GameObject>();

    public IEnumerator MonsterSpawn()
    {
        yield return new WaitForSeconds(startSpawnTime);
        foreach(GameObject monster in monsters)
        {
            Instantiate(monster);
        }
    }
}
