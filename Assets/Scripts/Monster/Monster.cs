using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
    }
}
