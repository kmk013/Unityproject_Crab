using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(GetComponent<MonsterSpawner>().MonsterSpawn());
    }
}
