using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float timeMax;
    float timer;
    public float yMax;
    public float yMin;
    float yRandom;
    // Start is called before the first frame update
    void Start()
    {
        //engeller oyuna baslamak icin tiklandiktan sonra aktiflestirilecek
        //InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        //oyun bitmemis ve oyuna baslandiysa yeni engel uretir
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeMax)
            {
                yRandom = Random.Range(yMin, yMax);
                InstantiateObstacle();
                timer = 0;
            }
        }
        
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, yRandom);
    }
}
