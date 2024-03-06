using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const string SCENE_MENU = "Menu";
    const string SCENE_ADVENTURE = "Adventure";

    public static GameManager instance;
    // Start is called before the first frame update
    [SerializeField]
    float initiallyGameSpeed = 0.5f;
    [SerializeField]
    float gameSpeedIncrease = 0.01f;
    [SerializeField]
    float gameSpeed;
    public float score { get; private set; }

    public float getGameSpeed() => gameSpeed;
    private void Awake()
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
    void Start()
    {
        gameSpeed = initiallyGameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    public void SaveScore()
    {
        float score1 = PlayerPrefs.GetFloat("score1");
        float score2 = PlayerPrefs.GetFloat("score2");
        float score3 = PlayerPrefs.GetFloat("score3");
        if (score > score1)
        {
            score3 = score2;
            score2 = score1;
            score1 = score;
        }
        else if (score > score2)
        {
            score3 = score2;
            score2 = score;
        }
        else if (score > score3)
        {
            score3 =score;
        }
        PlayerPrefs.SetFloat("score1", score1);
        PlayerPrefs.SetFloat("score2", score2);
        PlayerPrefs.SetFloat("score3", score3);
    }
    
    public (float, float, float ) GetScore()
    {
        float score1 = PlayerPrefs.GetFloat("score1");
        float score2 = PlayerPrefs.GetFloat("score2");
        float score3 = PlayerPrefs.GetFloat("score3");
        return (score1, score2, score3);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
