using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectCoins : MonoBehaviour
{
    [SerializeField] float _sizeCoins;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            Debug.Log("Collect coin");
            Scale scriptScale = GetComponent<Scale>();
            scriptScale.scale(_sizeCoins);

            GameObject ObjectDestroy = collision.gameObject;
            Destroy(ObjectDestroy);
        }
    }

    void Destroy(GameObject objectDestroy)
    {
        Destroy(objectDestroy);
    }
}
