using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public GameObject patrolZone; // R�f�rence � la zone de d�placement en forme de cercle.
    public float patrolSpeed = 2.0f; // Vitesse de d�placement.

    private Vector2 targetPosition;

    private void Start()
    {
        GetRandomPositionInZone();
    }

    private void Update()
    {
        // D�placez l'ennemi vers la position cible.
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);

        // V�rifiez si l'ennemi a atteint sa destination.
        if ((Vector2)transform.position == targetPosition)
        {
            GetRandomPositionInZone();
        }
    }

    private void GetRandomPositionInZone()
    {
        Vector2 zoneCenter = patrolZone.transform.position;
        float zoneRadius = patrolZone.GetComponent<CircleCollider2D>().radius;

        float randomAngle = Random.Range(0f, 360f);
        Vector2 randomDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;

        targetPosition = zoneCenter + randomDirection * Random.Range(0f, zoneRadius);
    }
}
