using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public int score;
    public int high_score;
    public void Start()
    {
        score = 0;
    }

    public void incrementScore()
    {
        score += 1;
    }




}
