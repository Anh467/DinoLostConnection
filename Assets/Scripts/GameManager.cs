using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
