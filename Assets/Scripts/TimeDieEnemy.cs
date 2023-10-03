using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDieEnemy : MonoBehaviour
{
    [SerializeField] float timer;

    void Start()
    {
        StartCoroutine(endTimer());
    }

    private IEnumerator endTimer()
    {
        yield return new WaitForSeconds(timer);
        FindObjectOfType<SpawnCoins>().spawnEnemyList.Remove(transform.position);
        Destroy(gameObject);
    }

    public void restartTimer()
    {
        StopCoroutine(endTimer());
        StartCoroutine(endTimer());
    }

}
