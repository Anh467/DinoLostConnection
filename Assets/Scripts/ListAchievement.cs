using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListAchievement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI tmp_Score1;
    [SerializeField]
    TextMeshProUGUI tmp_Score2;
    [SerializeField]
    TextMeshProUGUI tmp_Score3;
    private void Start()
    {
        var score = GameManager.instance.GetScore();
        tmp_Score1.text = score.Item1.ToString();
        tmp_Score2.text = score.Item2.ToString();
        tmp_Score3.text = score.Item3.ToString();
    }
}
