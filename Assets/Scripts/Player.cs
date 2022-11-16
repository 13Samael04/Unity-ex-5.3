using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _coinCounts;

    private int _leath = 1;
    private Rigidbody2D _rigidebody2d;
    private BoxCollider2D _boxCollider2d;

    private void Start()
    {
        _rigidebody2d = GetComponent<Rigidbody2D>();
        _boxCollider2d = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            _leath--;
            StartCoroutine(Dead());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            _coinCounts++;
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator Dead()
    {
        float forse = 4;
        _rigidebody2d.AddForce(transform.up * forse, ForceMode2D.Impulse);
        _boxCollider2d.enabled = false;
        yield return null;
    }
}
