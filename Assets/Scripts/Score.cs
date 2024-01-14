using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    int scoreHigh;
    public Text panelScore;
    public Text panelHighScore;
    public GameObject New;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        scoreHigh = PlayerPrefs.GetInt("scoreHigh");
        panelHighScore.text = scoreHigh.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        if (score > scoreHigh)
        {
            scoreHigh = score;
            panelHighScore.text = scoreHigh.ToString();
            PlayerPrefs.SetInt("scoreHigh", scoreHigh);
            New.SetActive(true);
        }
    }

    public int GetScore(){
        return score;
    }
}
