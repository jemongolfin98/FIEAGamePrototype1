using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject introTutorial;
    public GameObject blasterTutorial;
    public GameObject shieldTutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseIntroTutorial()
    {
        introTutorial.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CloseBlasterTutorial()
    {
        blasterTutorial.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CloseShieldTutorial()
    {
        shieldTutorial.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
