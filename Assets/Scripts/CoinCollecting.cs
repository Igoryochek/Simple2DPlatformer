using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Destroy(collision.gameObject);
        }
    }
}
