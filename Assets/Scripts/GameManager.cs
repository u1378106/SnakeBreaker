using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    Trajectory trajectory;
    Ball ball;

    [SerializeField] float ballSpeed;

    private Vector3 mousePosition;
    float zDept;
    bool ballServed = false;

    public static int score = 0;

    [SerializeField]
    public GameObject gameOver;

    [SerializeField]
    public GameObject gameWin;

    [SerializeField]
    TextMeshProUGUI scoreText;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        gameWin.SetActive(false);
        scoreText.text = "Score: " + 0;
        gameOver.SetActive(false);
        ball = FindObjectOfType<Ball>();
        trajectory = FindObjectOfType<Trajectory>();
        zDept = Camera.main.transform.position.z - transform.position.z;
        mousePosition = new Vector3(0f, 0f, zDept);
    }
    public bool IsBallServed()
    {
        return ballServed;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (!ballServed)
        {
            trajectory.Show();
            mousePosition.x = Input.mousePosition.x;
            mousePosition.y = Input.mousePosition.y;
            trajectory.UpdateDots(Camera.main.WorldToScreenPoint(ball.Position), mousePosition);
            if (Input.GetKeyDown(KeyCode.Mouse0))
                ServeBall();
        }
        else
        {
            ball.CheckVelocity();
        }

        if(GameObject.FindGameObjectsWithTag("snake").Length == 0)
        {
            audioManager.gameWin.Play();
            gameWin.SetActive(true);

            Destroy(ball);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("snake"))
            {
                Destroy(go);
            }
            Destroy(this);
        }
       

    }
    void ServeBall()
    {
        ballServed = true;
        trajectory.Hide();
        // Update mouse position at the launch time
        mousePosition.x = Input.mousePosition.x;
        mousePosition.y = Input.mousePosition.y;

        Destroy(GameObject.Find("Instruction Text"));
        Cursor.visible = false;

        Vector3 ballPosition = Camera.main.WorldToScreenPoint(ball.Position); // ball position in Screenpoint

        // Caculate the direction
        Vector3 direction = (mousePosition - ballPosition);
        direction = direction.normalized;

        Vector2 force = new Vector2(direction.x * ballSpeed, direction.y * ballSpeed);

        ball.AddForce(force);
    }
}
