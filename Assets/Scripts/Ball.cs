using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    bool hasStarted = false;

    Paddle paddle;
    Vector3 paddleToBallVector;
    float paddleToBallVectorX;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }
	    
	// Update is called once per frame
	void Update () {

        if(!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0)) {
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }

        print(paddleToBallVector);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name == "Paddle")
        {
            paddleToBallVectorX = (this.transform.position.x - paddle.transform.position.x) * 15;

            Vector2 tweak = new Vector2(paddleToBallVectorX, 10f);
            this.GetComponent<Rigidbody2D>().velocity = tweak;
        }

        
    }
}
