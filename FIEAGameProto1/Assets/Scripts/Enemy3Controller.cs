using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int enemy3health;

    public GameObject enemy3;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemy3health = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemy3health = enemy3health - 1;
            SetEnemyHealth();
        }
    }

    public void SetEnemyHealth()
    {
        if (enemy3health <= 0)
        {
            enemy3.gameObject.SetActive(false);
        }
    }
}
