using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Transform tail;

    private Vector2 startPos;

    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;

        tail = transform.GetChild(transform.childCount - 1);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x >= 20)
        {
            this.transform.position = startPos;
        }

        //if (transform.childCount <= (transform.childCount)/2)
        //{
        //    Destroy(this.gameObject);
        //}

        this.transform.Translate(new Vector2(1, 0) * Time.deltaTime * Random.Range(0.1f, speed));
    }

   
}
