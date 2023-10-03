using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] float size;
    [SerializeField] GameObject CoinsPrefab;
    [SerializeField] GameObject EnemyPrefab;

    public GameObject spawnPoint;
    private GameObject respawn;
    private GameObject respawnEnemy;

    [SerializeField] float margin;

    public List<Vector2> spawnList = new List<Vector2>();
    public List<Vector2> spawnEnemyList = new List<Vector2>();

    public float spawnCooldown = 3f;
    public float spawnEnemyCooldown = 3f;

    [SerializeField] bool Cooldown = true;
    [SerializeField] bool CooldownEnemy = true;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (Cooldown)
        {
            random();
            randomEnemy();
        }
    }

    public void random()
    {
        Vector3 position = Random.insideUnitCircle * size;
        position.z = 8f;

        spawnPoint.transform.position = position;

        Cooldown = false;

        StartCoroutine(spawnTime());

        bool succeed = true;

        if (spawnList.Count == 0)
        {
            spawnCoins();
            return;
        }

        foreach (Vector2 trez in spawnList)
        {
            if (Vector2.Distance(trez, spawnPoint.transform.position) < margin)
            {
                succeed = false;
                break;
            }
        }


        if (succeed)
        {
            spawnCoins();
        }
        else random();
    }

    public void randomEnemy()
    {
        Vector3 position = Random.insideUnitCircle * size;
        position.z = 8f;

        spawnPoint.transform.position = position;

        CooldownEnemy = true;

        StartCoroutine(spawnTimeEnemy());

        bool succedEnemy = true;

        if (spawnEnemyList.Count == 0)
        {
            spawnEnemy();
            return;
        }


        foreach (Vector2 trez in spawnEnemyList)
        {
            if (Vector2.Distance(trez, spawnPoint.transform.position) < margin)
            {
                succedEnemy = false;
                break;
            }
        }

        if (succedEnemy)
        {
            spawnEnemy();
        }
        else random();
    }

    private void spawnCoins()
    {
        spawnList.Add(spawnPoint.transform.position);

        GameObject coinToSpawn = CoinsPrefab;

        respawn = Instantiate(coinToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);

        foreach (Vector2 truc in spawnList)
        {
            print(truc);
            print(spawnList.Count);
        }
    }

    private void spawnEnemy()
    {
        spawnEnemyList.Add(spawnPoint.transform.position);

        GameObject enemyToSpawn = EnemyPrefab;

        Vector3 scale = enemyToSpawn.transform.localScale;

        respawnEnemy = Instantiate(enemyToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);

        respawnEnemy.transform.localScale = scale;


        foreach (Vector2 truc in spawnEnemyList)
        {
            print(truc);
            print(spawnList.Count);
        }
    }

    private IEnumerator spawnTime()
    {
        yield return new WaitForSeconds(spawnCooldown);
        Cooldown = true;
    }

    private IEnumerator spawnTimeEnemy()
    {
        yield return new WaitForSeconds(spawnEnemyCooldown);
        CooldownEnemy = true;
    }

    void resetCoin()
    {
        GameObject[] coinsToDestroy = GameObject.FindGameObjectsWithTag("Coins");

        foreach (GameObject obj1 in coinsToDestroy)
        {
            spawnList.Clear();
            Destroy(obj1);
        }
    }

    void resetEnemy()
    {
        GameObject[] enemyToDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj2 in enemyToDestroy)
        {
            spawnEnemyList.Clear();
            Destroy(obj2);
        }
    }

    [Button] void SpawnsCoins() => random();
    [Button] void ResetCoins() => resetCoin();

    [Button] void ResetEnemys() => resetEnemy();
    [Button] void SpawnEnemys() => randomEnemy();
}
