using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Spawn Related Stuff")]
    public float spawnrate = 1f;
    public int spawnAmout = 1;
    public float spawnDistance = 25f;
    public float spawnVariance = 15f;

    [Header("Prefab List")]
    public abstractAsteroid[] asteroids;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {

        for(int i  = 0; i < spawnAmout; i++)
        {
            Vector3 spawnDirection = Random.insideUnitSphere.normalized * spawnDistance;
            Vector3 spawnPosition = transform.position + spawnDirection;

            float Variance = Random.Range(-spawnVariance, spawnVariance);
            Quaternion spawnRotation = Quaternion.AngleAxis(Variance, Vector3.forward);

            int randInt = Random.Range(0, 2);

            abstractAsteroid asteroid = Instantiate(asteroids[randInt], spawnPosition, spawnRotation);
            asteroid.setTrajectory(spawnRotation * -spawnDirection);
        }

    }
}
