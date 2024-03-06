using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Information_Management : MonoBehaviour
{
    public static UI_Information_Management instance;

    [SerializeField]
    TextMeshProUGUI tmpScore;

    [SerializeField]
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tmpScore.text = "Score: " + GameManager.instance.score.ToString("F2");

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (pausePanel.active)
            {
                Continue();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1;
        GameManager.instance.LoadScene("Menu");
    }
}
