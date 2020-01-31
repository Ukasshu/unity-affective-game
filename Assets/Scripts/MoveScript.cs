using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Feedback.Model;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    public float gameSpeed = 1.0F;
    public float time = 40.0f;
    public float lastTime = 0;

    public HoldButton leftButton;
    public HoldButton rightButton;
    public HoldButton jumpButton;
    public Button pauseButtton;
    public Button restartButton;
    public Button opinionButton;
    public Text livesText;
    public Text coinsText;
    public Text timeText;

    public CharacterController characterController;
    public SpriteRenderer spriteRenderer;

    public float horizontalSpeed = 0;
    public float verticalSpeed = 0;

    public bool gameOver = false;

    public int lives = 3;
    int coins = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        opinionButton.gameObject.SetActive(false);
        pauseButtton.onClick.AddListener(PauseOnClick);
        restartButton.onClick.AddListener(RestartOnClick);
        opinionButton.onClick.AddListener(OpinionOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        KeyPressed();
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if (jumpButton.buttonPressed && gameSpeed != 0 && GetComponent<CharacterController>().isGrounded) {
            verticalSpeed = 20;
            jumpButton.buttonPressed = false;
        }

        if (leftButton.buttonPressed && !rightButton.buttonPressed && gameSpeed != 0)
        {
            horizontalSpeed = -5;
            spriteRenderer.flipX = true;
        }

        if(rightButton.buttonPressed && !leftButton.buttonPressed && gameSpeed != 0)
        {
            horizontalSpeed = 5;
            spriteRenderer.flipX = false;
        }


        moveDirection.x = gameSpeed * horizontalSpeed;
        horizontalSpeed -= gameSpeed * Math.Sign(horizontalSpeed);

        moveDirection.y = gameSpeed * verticalSpeed;

        if (verticalSpeed > -15.0F)
            verticalSpeed-= (gameSpeed * 100 * Time.deltaTime);

        characterController.Move(moveDirection*Time.deltaTime); 

        time -= Time.deltaTime * gameSpeed;

        if (time <= 0) {
            gameSpeed = 0.0f;
            gameOver = true;
            time = 0;
        }

        timeText.text = "Time: " + time.ToString("000.00");
    }

    void PauseOnClick()
    {
        if (gameSpeed == 1.0F)
        {
            gameSpeed = 0.0F;
            restartButton.gameObject.SetActive(true);
            opinionButton.gameObject.SetActive(true);
        }
        else if (!gameOver)
        {
            gameSpeed = 1.0F;
            restartButton.gameObject.SetActive(false);
            opinionButton.gameObject.SetActive(false);
        }
    }

    void RestartOnClick()
    {
        var guid = GameObject.Find("PlayerGuid").GetComponent<PlayerGuidScript>().playerGuid;
        Log(this.time, this.lives, this.coins);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

    void OpinionOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    }

    private async void Log(double time, int lives, int coins)
    {
        using(var context = new aml_projectContext())
        {
            var logEntry = new LogEntry()
            {
                PlayerGuid = GameObject.Find("PlayerGuid").GetComponent<PlayerGuidScript>().playerGuid,
                RestartTime = time,
                Lifes = lives,
                Coins = coins
                
            };

            await context.LogEntry.AddAsync(logEntry);
            await context.SaveChangesAsync();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "water")
        {
            Debug.Log("DEAD");
            gameSpeed = 0;
            gameOver = true;
        }
    }

    private void KeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<CharacterController>().isGrounded)
            jumpButton.buttonPressed = true;
            
        if (Input.GetKeyUp(KeyCode.Space))
            jumpButton.buttonPressed = false;

        if (Input.GetKeyDown(KeyCode.A))
            leftButton.buttonPressed = true;

        if (Input.GetKeyUp(KeyCode.A))
            leftButton.buttonPressed = false;
            
        if (Input.GetKeyDown(KeyCode.D))
            rightButton.buttonPressed = true;

        if (Input.GetKeyUp(KeyCode.D))
            rightButton.buttonPressed = false;

        if (Input.GetKeyDown(KeyCode.R))
            RestartOnClick();

    }

    public void DeacreaseLives() 
    {
        lives--;
        livesText.text = "Lives: " + lives; 
    }

    public void IncreaseCoins()
    {
        coins++;
        coinsText.text = "Coins: " + coins + "/4";
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "tile") {
            verticalSpeed = 0;            
        }

    }
}
