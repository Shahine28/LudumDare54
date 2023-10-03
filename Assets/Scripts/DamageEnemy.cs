using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] float _downScale;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject _player = GameObject.Find("Player");
        Scale _scale = _player.GetComponent<Scale>();

        GameObject _manager = GameObject.Find("GameManager");
        Scores _score = _manager.GetComponent<Scores>();

        if (collision.CompareTag("Player") && _scale._downScale)
        {
            _scale.downScale(_downScale);
            _score.ScoreDown(1);
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
