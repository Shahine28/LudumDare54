using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float _downScale;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _player = GameObject.Find("Player");
        Scale scale = _player.GetComponent<Scale>();

        if (collision.CompareTag("Player") && scale._downScale)
        {
            scale.downScale(_downScale);
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
