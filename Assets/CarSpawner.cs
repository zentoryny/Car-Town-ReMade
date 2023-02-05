using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    public Transform CarPrefab;

    public Transform spawnPoint;
    public float timeBetweenCars = 10f;
    private float countdown = 3f;

    private int waveIndex = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenCars;
        }

        countdown -= Time.deltaTime;
    }

    
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.0f);
        }

        
    }

    void SpawnEnemy ()
    {
        Instantiate(CarPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
