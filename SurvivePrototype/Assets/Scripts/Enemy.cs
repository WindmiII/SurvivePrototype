using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTarget;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
