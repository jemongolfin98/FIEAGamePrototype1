using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce;
    private Rigidbody2D rb2d;
    public Text healthText;
    public GameObject enemyHealth;
    public Text gameOverText;
    public Text gameOverText1;
    public Text blasterCreationText;
    public Text shieldCreationText;
    public GameObject blaster;
    public GameObject shield;
    public GameObject gameOverScreen;
    public GameObject gameActiveScreen;
    public GameObject introTutorialScreen;
    public GameObject blasterTutorialScreen;
    public GameObject shieldTutorialScreen;
    public GameObject enemyLock;
    public GameObject enemyBoss;
    public GameObject gameEnvironment;

    private int health;
    private int blasterPart;
    private int shieldPart;
    private bool gameOver;
    private bool blasterActive;
    private bool shieldActive;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = 10;
        blasterPart = 0;
        shieldPart = 0;
        introTutorialScreen.SetActive(true);
        blasterActive = false;
        shieldActive = false;
        SetHealth();
        BlasterCreation();
        ShieldCreation();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (gameOver == true)
        {
            GameOver();
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (blasterActive == true && shieldActive == false)
            {
                blaster.SetActive(false);
                blasterActive = false;
                shield.SetActive(true);
                shieldActive = true;
            }
            else if (blasterActive == false && shieldActive == true)
            {
                blaster.SetActive(true);
                blasterActive = true;
                shield.SetActive(false);
                shieldActive = false;
            }

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb2d.velocity = new Vector2(speed * -1, rb2d.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow))
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //Allows Player to Jump if on the Ground
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        //Allows Player to Jump if on a Platform
        if (collision.collider.tag == "Platform")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy1"))
        {
            health = health - 1;
            SetHealth();
        }

        if (other.gameObject.CompareTag("Enemy2"))
        {
            health = health - 1;
            SetHealth();
        }

        if (other.gameObject.CompareTag("Enemy3"))
        {
            health = health - 1;
            SetHealth();
        }

        if (other.gameObject.CompareTag("EnemyBoss"))
        {
            health = health - 2;
            SetHealth();
        }

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            health = health - 1;
            SetHealth();
        }

        if (other.gameObject.CompareTag("EnemyBossBullet"))
        {
            health = health - 2;
            SetHealth();
        }

        if (other.gameObject.CompareTag("HealthPickup"))
        {
            other.gameObject.SetActive(false);
            health = health + 2;
            SetHealth();
        }

        if (other.gameObject.CompareTag("BlasterPart"))
        {
            other.gameObject.SetActive(false);
            blasterPart = blasterPart + 1;
            BlasterCreation();
        }

        if (other.gameObject.CompareTag("ShieldPart"))
        {
            other.gameObject.SetActive(false);
            shieldPart = shieldPart + 1;
            ShieldCreation();
        }

        if (other.gameObject.CompareTag("EnemyTrigger"))
        {
            enemyLock.SetActive(true);
            enemyBoss.SetActive(true);
            enemyHealth.SetActive(true);
        }
    }

    public void SetHealth()
    {
        healthText.text = "Health: " + health + " Lives";

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void BlasterCreation()
    {
        blasterCreationText.text = "Blaster Parts: " + blasterPart + " Part(s)";

        if (blasterPart >= 5)
        {
            blasterCreationText.text = "Blaster Acquired";
            blaster.SetActive(true);
            shield.SetActive(false);
            blasterTutorialScreen.SetActive(true);
            blasterActive = true;
            shieldActive = false;
            Time.timeScale = 0f;
        }
    }

    public void ShieldCreation()
    {
        shieldCreationText.text = "Shield Parts: " + shieldPart + " Part(s)";

        if (shieldPart >= 4)
        {
            shieldCreationText.text = "Shield Acquired";
            shield.SetActive(true);
            blaster.SetActive(false);
            shieldTutorialScreen.SetActive(true);
            blasterActive = false;
            shieldActive = true;
            Time.timeScale = 0f;
        }
    }

    public void CloseTutorial()
    {
        blasterTutorialScreen.SetActive(false);
        shieldTutorialScreen.SetActive(false);
    }

    public void GameActive()
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
        speed = 0;
        jumpForce = 0;
        Time.timeScale = 0f;
        gameActiveScreen.SetActive(false);
        gameEnvironment.SetActive(false);
        gameOverScreen.SetActive(true);

        if (health <= 0)
        {
            gameOverText.text = "GAME OVER";
            gameOverText1.text = "Better luck next time!";
        }
        else
        {
            gameOverText.text = "SUCCESS!!!";
            gameOverText1.text = "Great Job!";
        }
    }
}
