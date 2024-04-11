using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public GameObject GOP;
    public Button retryButton;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    private int Score = 0;
    public float strength = 5f; 
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        GOP.SetActive(false);
        retryButton.onClick.AddListener(RetryGame);
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {

            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obst"))
        {
            
            GOP.SetActive(true);
            Time.timeScale = 0;
        }
        else if (other.gameObject.CompareTag("score"))
        {
            Score++;
            UpdateScoreText();
        }
    }
    private void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }
}
