using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject slicedFruitPrefab;
    [SerializeField] private float minExplosionForce = 500f;
    [SerializeField] private float maxExplosionForce = 1000f;

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }*/
    }

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce),
                transform.position + new Vector3(0f, Random.Range(-0.1f, 0.1f), 0.1f),
                5f);
        }

        FindObjectOfType<GameManager>().IncreaseScore(2);
        
        Destroy(inst, 5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Blade b = col.GetComponent<Blade>();
        if (!b)
            return;
        
        CreateSlicedFruit();
    }
}