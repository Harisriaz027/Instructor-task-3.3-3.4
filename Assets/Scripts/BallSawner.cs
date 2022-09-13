using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSawner : MonoBehaviour
{
    public GameObject ballPrefabs;
    void Start()
    {
        InvokeRepeating("spawner", 2, 10);
    }

    public void spawner()
    {
        Vector3 spawnPos = new Vector3(0, 18, 0);
        Instantiate(ballPrefabs, spawnPos, ballPrefabs.transform.rotation);
    }
}
