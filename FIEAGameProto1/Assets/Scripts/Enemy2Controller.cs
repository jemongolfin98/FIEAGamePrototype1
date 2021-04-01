using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int enemy2health;

    public GameObject enemy2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemy2health = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemy2health = enemy2health - 1;
            SetEnemyHealth();
        }
    }

    public void SetEnemyHealth()
    {
        if (enemy2health <= 0)
        {
            enemy2.gameObject.SetActive(false);
        }
    }
}
