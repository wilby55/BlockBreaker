using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    bool hasStarted = false;
    Ball ball;
    float autoRand = 0;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted) { MoveWithMouse(); }
        else
        {
            if (autoPlay) { MoveAuto(); }
            else { MoveWithMouse(); }
        }
        
        if (Input.GetMouseButtonDown(0)) { hasStarted = true; }
    }

    void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, 0f);
        this.transform.position = paddlePos;
    }

    void MoveAuto()
    {
        Vector3 paddlePos = new Vector3(Mathf.Clamp(ball.transform.position.x + autoRand, 0.5f, 15.5f), this.transform.position.y, 0f);
        this.transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {

            this.GetComponent<AudioSource>().Play();
            autoRand = Random.Range(-0.55f, 0.55f);
        }
    }
}
