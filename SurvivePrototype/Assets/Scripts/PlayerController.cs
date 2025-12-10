using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public int health = 3;

    void Update()
    {
        walk();
        input();
    }

    void walk() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
    }

    void input()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public void TakeDamage()
    {
        health--;

        GameEvents.OnPlayerDamaged?.Invoke(health);

        if (health <= 0)
        {
            GameEvents.OnGameOver?.Invoke();
            
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
}
