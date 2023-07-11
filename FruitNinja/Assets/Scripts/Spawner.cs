using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitToSpawn;
    public Transform[] spawnPlaces;
    public float minWait = 0.1f;
    public float maxWait = 1f;
    public float minForce = 10;
    public float maxForce = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject fruit = Instantiate(fruitToSpawn, t.position, t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce),
                ForceMode2D.Impulse);

            Debug.Log("Spawned fruit");

            Destroy(fruit, 5);
        }
    }
}