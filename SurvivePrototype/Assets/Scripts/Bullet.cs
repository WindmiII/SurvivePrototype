using UnityEngine;
using UnityEngine.UI;

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
            GameManager.score += Random.Range(5,10);
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + GameManager.score;
            
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }
    }
}