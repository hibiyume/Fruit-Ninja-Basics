using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsToSpawn;
    [SerializeField] private GameObject bombToSpawn;
    [SerializeField] private Transform[] spawnPlaces;
    [SerializeField] private float minWait = 0.3f;
    [SerializeField] private float maxWait = 1f;
    [SerializeField] private float minForce = 9f;
    [SerializeField] private float maxForce = 14f;
    [SerializeField] private float minRotationForce = 1f;
    [SerializeField] private float maxRotationForce = 3f;

    private void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    private IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)]; // Spawners positions

            GameObject fruitPrefab; // To choose what to spawn
            float p = Random.Range(0f, 100f);
            if (p < 10f) // 10% for bomb
                fruitPrefab = bombToSpawn;
            else
                fruitPrefab = fruitsToSpawn[Random.Range(0, fruitsToSpawn.Length)];

            GameObject fruit = Instantiate(fruitPrefab, t.position, fruitPrefab.transform.rotation); // Spawning fruit

            fruit.GetComponent<Rigidbody2D>()
                .AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            fruit.GetComponent<Rigidbody2D>()
                .AddTorque(Random.Range(minRotationForce, maxRotationForce), ForceMode2D.Impulse);


            Destroy(fruit, 5f);
        }
    }
}