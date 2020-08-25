using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float waveMaxTime;
    public bool isWaveEnd;
    public float timeBetweenSpawn;
    public GameObject[] enemyTypes;
    public Transform [] spawnPoints;
    private float startWaveTime = 0;
    IEnumerator Start()
    {
        isWaveEnd = false;

        while (true)
        {
            startWaveTime += Time.deltaTime;

            if (startWaveTime <= (waveMaxTime / 3))
            {
                Instantiate(enemyTypes[0], spawnPoints[Random.Range(0,spawnPoints.Length)]);
                yield return new WaitForSeconds(timeBetweenSpawn);
                startWaveTime += timeBetweenSpawn;
            }

            if ((startWaveTime > (waveMaxTime / 3)) && (startWaveTime < 2 * (waveMaxTime / 3)))
            {
                Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
                yield return new WaitForSeconds(timeBetweenSpawn - timeBetweenSpawn*(1/3));
                startWaveTime += timeBetweenSpawn;
            }

            if ((startWaveTime >= 2 * (waveMaxTime / 3)) && (startWaveTime <= waveMaxTime))
            {
                Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
                yield return new WaitForSeconds(timeBetweenSpawn - timeBetweenSpawn * (1/3));
                startWaveTime += timeBetweenSpawn;
            }

            if (startWaveTime > waveMaxTime)
            {
                isWaveEnd = true;
                yield return new WaitForSeconds(5f);
                isWaveEnd = false;
                startWaveTime = 0;
            }
            yield return new WaitForSeconds(.01f);
        }
    }
}
