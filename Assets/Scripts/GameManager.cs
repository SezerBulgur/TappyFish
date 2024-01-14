using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject getReadyPanel;
    public static bool gameOver;
    public static Vector2 bottomLeft;
    public static bool gameStarted;
    public static int gameScore;
    public GameObject score;
    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        //oyun bitince skor yazisini silen kod
        score.SetActive(false);
        //oyun bitince skoru alan kod
        gameScore = score.GetComponent<Score>().GetScore();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        //oyuna baslandiginda get ready panelini gizler
        getReadyPanel.SetActive(false);
    }
}
