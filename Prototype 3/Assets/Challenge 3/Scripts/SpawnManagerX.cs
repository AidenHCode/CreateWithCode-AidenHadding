﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 0.1f;
    private float spawnInterval = 0.5f;
    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnInterval);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObject()
    {
        //Debug.Log("Spawn Object Ran");
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}