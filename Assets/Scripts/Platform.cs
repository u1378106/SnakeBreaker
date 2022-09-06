using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Ball Ball;
    //private AudioManager audioManager;
    private GameManager gameManager;
    [SerializeField]
    private bool autoPlay;
    private float zDistance, leftCorner, rightCorner;
    private int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Ball = FindObjectOfType<Ball>();

        // Restrict paddle position
        zDistance = transform.position.z - Camera.main.transform.position.z;
        // 
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        leftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDistance)).x + sprite.bounds.size.x / 2;
        rightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDistance)).x - sprite.bounds.size.x / 2;
    }
    
    // Update is called once per frame

    private void MovePlatform()
    {
        if(Input.GetKey(KeyCode.A) && this.transform.position.x >= leftCorner)
        {
            this.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.D) && this.transform.position.x <= rightCorner)
        {
            this.transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
        }
    }
 
    void Update()
    {
        if (gameManager.IsBallServed())
            MovePlatform();
    }
}
