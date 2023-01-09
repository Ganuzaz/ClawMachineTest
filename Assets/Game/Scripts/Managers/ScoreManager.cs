using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public TextMeshProUGUI prizesText;

    private Dictionary<PrizeType, int> prizeScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        prizeScore = new Dictionary<PrizeType, int>();

        PrizeType[] prizeTypes = (PrizeType[])System.Enum.GetValues(typeof(PrizeType));

        foreach(var prizeType in prizeTypes)
        {
            prizeScore.Add(prizeType, 0);
        }

        EventManager.instance.AddListener(EventEnums.PRIZE_ON_DROPPED, OnPrizeGained);

        UpdateScore();
    }

    void OnPrizeGained(Hashtable table)
    {
        prizeScore[(PrizeType)table["prizeType"]]++;
        UpdateScore();
    }

    void UpdateScore()
    {
        StringBuilder prizeText = new StringBuilder();

        foreach (var score in prizeScore)
        {
            prizeText.Append($"{score.Key} : {score.Value}");
            prizeText.Append(System.Environment.NewLine);
        }

        prizesText.text = prizeText.ToString();
    }
    
}
