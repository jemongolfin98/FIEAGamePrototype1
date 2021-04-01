using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int enemy1health;

    public GameObject enemy1;
    public GameObject enemy1BulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemy1health = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemy1health = enemy1health - 1;
            SetEnemyHealth();
        }
    }

    public void SetEnemyHealth()
    {
        if (enemy1health <= 0)
        {
            //enemy1.gameObject.SetActive(false);
            //enemy1BulletSpawn.SetActive(false);
            Destroy(gameObject);

        }
    }
}
