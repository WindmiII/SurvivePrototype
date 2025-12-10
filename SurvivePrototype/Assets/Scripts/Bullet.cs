using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timeSpan = 3f;

    void Start()
    {
        Destroy(gameObject, timeSpan);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            int scoreToAdd = Random.Range(5, 10);
            GameEvents.OnEnemyKilled?.Invoke(scoreToAdd);
            
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }
    }
}