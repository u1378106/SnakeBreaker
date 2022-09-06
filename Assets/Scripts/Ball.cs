using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private Platform platform;
    private Vector3 ballToPaddle;

    private int min = 1;
    private int max = 3;

    GameManager gameManager;
    AudioManager audioManager;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        platform = GameObject.FindObjectOfType<Platform>();
        ballRb = GetComponent<Rigidbody2D>();
    }
    public void AddForce(Vector2 force)
    {
        ballRb.AddForce(force, ForceMode2D.Impulse);
    }
 

    public void CheckVelocity()
    {
        // Prevent ball from rolling in the same directon forever
        if (ballRb.velocity.x == 0)
        {
            ballRb.velocity = new Vector2(Random.Range(min, max), ballRb.velocity.y);
        }
        else if (ballRb.velocity.y == 0)
        {
            ballRb.velocity = new Vector2(ballRb.velocity.x, Random.Range(min, max));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "snake")
        {
            GameManager.score++;
            audioManager.snakeHitAudio.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "platform")
        {
            audioManager.bounceAudio.Play();
        }

        if (other.gameObject.tag == "gameover")
        {      
            gameManager.gameOver.SetActive(true);
            audioManager.bgAudio.Stop();
            audioManager.gameOverAudio.Play();
            Destroy(gameManager);
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("snake"))
            {
                Destroy(go);
            }
            Destroy(this.gameObject);
        }
    }
}
