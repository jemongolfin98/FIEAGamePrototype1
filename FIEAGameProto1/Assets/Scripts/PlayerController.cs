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
    public Text finalScoreText;
    public Text gameOverText;
    public Text gameOverText1;
    public Text blasterCreationText;
    public Text shieldCreationText;
    public GameObject blaster;
    public GameObject shield;
    public GameObject gameOverScreen;
    public GameObject gameActiveScreen;
    public GameObject blasterTutorialScreen;
    public GameObject shieldTutorialScreen;

    private int health;
    private int blasterPart;
    private int shieldPart;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = 10;
        blasterPart = 0;
        shieldPart = 0;
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
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
            blasterTutorialScreen.SetActive(true);
        }
    }

    public void ShieldCreation()
    {
        shieldCreationText.text = "Blaster Parts: " + shieldPart + " Part(s)";

        if (shieldPart >= 4)
        {
            shieldCreationText.text = "Blaster Acquired";
            shield.SetActive(true);
            shieldTutorialScreen.SetActive(true);
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
