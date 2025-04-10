using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnInterval = 2f;
    public float enemyspeed = 10f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnpoint = new Vector3(35, Random.Range(-5.5f, 11.5f), 0);
            Instantiate(enemy, spawnpoint, enemy.transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void IncreaseSpawnrate()
    {
        spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.2f);
        Debug.Log("Spawn rate increased! New interval: " + spawnInterval);
    }
    public void IncreaseEnemySpeed()
    {
        enemyspeed += 1f;
    }
}
