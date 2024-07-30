using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float spawnInterval = 2f;

    private PlayerController controller;


    private void OnEnable()
    {
        controller = FindAnyObjectByType<PlayerController>();
    }

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2f, spawnInterval);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab[Random.Range(0,obstaclePrefab.Length)], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (controller.isGameOver == true)
        {
            CancelInvoke();
        }
    }


}
