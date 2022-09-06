using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHandler : MonoBehaviour
{
    [SerializeField]
    private Sprite head;

    [SerializeField]
    private Sprite[] body;

    [SerializeField]
    private Sprite tail;

    [SerializeField]
    private int bodyPartsCount;

    [SerializeField]
    private GameObject[] spawnPositions;

    Vector3 snakeBodyPos;

    GameObject snake;

    private int snakeCount = 4;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= snakeCount; i++)
        {
            bodyPartsCount = Random.Range(4, 8);

            snake = new GameObject("Snake");
            snake = Instantiate(snake, Vector3.zero, Quaternion.identity, this.transform);

            GameObject snakeHead = Instantiate(Resources.Load("SnakeParts/SnakeHeadRight") as GameObject, (spawnPositions[Random.Range(0, spawnPositions.Length)]).transform.position, Quaternion.identity, snake.transform);
            snakeHead.tag = "snake";

            snakeBodyPos = new Vector3(snakeHead.transform.position.x, snakeHead.transform.position.y, 0);

            for (int j = 0; j <= bodyPartsCount; j++)
            {
                GameObject snakeBody = Instantiate(Resources.Load("SnakeParts/SnakeBody") as GameObject, new Vector3(snakeBodyPos.x - 0.3f, snakeBodyPos.y, 0), Quaternion.identity, snake.transform);
                snakeBodyPos = snakeBody.transform.position;
                snakeBody.tag = "snake";
            }

            GameObject snakeTail = Instantiate(Resources.Load("SnakeParts/SnakeTailRight") as GameObject, new Vector3(snakeBodyPos.x - 0.3f, snakeBodyPos.y, 0), Quaternion.identity, snake.transform);
            snakeTail.tag = "snake";

            snake.AddComponent<Snake>();
        }
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
