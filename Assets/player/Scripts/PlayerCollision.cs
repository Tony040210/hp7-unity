using System;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            int rand = UnityEngine.Random.Range(1, 10);
            gameManager.AddCoin(rand);
            Destroy(collision.gameObject);
        }
    }
}
