using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;


    public GameObject game_name_panel;
    public GameObject game_over_panel;
    public GameObject tap_panel;
    public GameObject score_panel;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI hightScore_text;
    public TextMeshProUGUI hightScore_text_2;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int high_score;


    public void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }



    public void Start()
    {
        high_score = PlayerPrefs.GetInt("HighScore");
        hightScore_text_2.text = high_score.ToString();

    }

    public void GameStart()
    {
        tap_panel.SetActive(false);
        game_name_panel.GetComponent<Animator>().Play("panelUp");
        score_panel.SetActive(true);

    }
    public void GameOver()
    {
        game_over_panel.SetActive(true);
        score_text.text = score.ToString();
        highScoreCheck();
        game_name_panel.SetActive(false);
        tap_panel.SetActive(false);
        score_panel.SetActive(false);

    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void TapTextClicked()
    {
        tap_panel.SetActive(false);
        GameStart();
    }

    public void highScoreCheck()
    {
      
       if(score>high_score)
       {
            high_score = score;
            PlayerPrefs.SetInt("HighScore",high_score);
       }

        hightScore_text.text = high_score.ToString();


    }







}//ui manager clas
