using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject [] carsPrefab;
    public float spawnInterval = 0f;
    public float spawnCooldown = 0f;

    void Start()
    {

    }

    void Update()
    {
        spawnCooldown += Time.deltaTime;
        if(spawnCooldown >= spawnInterval)
        {
            SpawnCar();
            spawnCooldown = 0;
            spawnInterval = Random.Range(0.3f, 3f);
        }
    }

    void SpawnCar()
    {
        Instantiate(carsPrefab[Random.Range(0, carsPrefab.Length)], transform.position, transform.rotation);
    }
}
