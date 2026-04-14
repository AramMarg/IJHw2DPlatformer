using UnityEngine;
using System;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D))]
public class Player : MonoBehaviour
{
    public event Action CoinGetted;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinGetted?.Invoke();

            coin.Interact();
        }
    }    
}
