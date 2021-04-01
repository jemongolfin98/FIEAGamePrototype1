using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int enemybosshealth;

    public GameObject enemyBoss;
    public Text enemyBossHealthText;
    public GameObject playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemybosshealth = 20;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemybosshealth = enemybosshealth - 1;
            SetEnemyHealth();
        }
    }

    public void SetEnemyHealth()
    {
        enemyBossHealthText.text = "Boss Health: " + enemybosshealth + " Lives";

        if (enemybosshealth <= 0)
        {
            enemyBoss.gameObject.SetActive(false);

            playerControllerScript.GetComponent<PlayerController>().GameOver();
        }
    }
}
