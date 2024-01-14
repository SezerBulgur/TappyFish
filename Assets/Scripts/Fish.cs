using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField]
    private float _speed;
    int angle;
    int angleMax = 20;
    int angleMin = -60;
    public Score score;
    public GameManager gameManager;
    bool groundTouched;
    public Sprite fishDied;
    SpriteRenderer spriteRenderer;
    Animator animator;
    [SerializeField] private AudioSource swim, hit, point;

    //engel ureticiye referans olusturma
    public ObstacleSpawner obstacleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        //baslarken balik havada kalir
        _rb.gravityScale = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();       
    }

    void FixedUpdate()
    {
        FishRotate();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            swim.Play();
            //oyun baslamamisken yapilan tiklama hareketinde gerekli islemleri yapan if blogu
            //else oyun baslamissa sadece balik hareketi yapar
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 4;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            } else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
            
        }
    }
    void FishRotate()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= angleMax)
            {
                angle = angle + 4;
            }
        }
        if (_rb.velocity.y < -1)
        {
            if (angle >= angleMin)
            {
                angle = angle - 2;
            }
        }

        if (groundTouched == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Score ..");
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Column"))
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                GameOver();
            }
        } //else blogu iptal denemesi 
        /*
        else 
        {
            GameOver();
        }
        */
    }

    void GameOver()
    {
        hit.Play();
        gameManager.GameOver();
        groundTouched = true;
        spriteRenderer.sprite = fishDied;
        animator.enabled = false;
        _rb.gravityScale = 0;
        _rb.velocity = Vector2.zero;
    }
}
