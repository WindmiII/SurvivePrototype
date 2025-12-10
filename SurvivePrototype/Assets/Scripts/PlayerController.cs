using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public int health = 3;
    public GameObject[] hearts;

    public GameObject restartButton;

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

        if (health >= 0 && health < hearts.Length)
        {
            hearts[health].SetActive(false);
        }

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;

        if (restartButton != null) 
        {
            restartButton.SetActive(true);
        }
    }
}
