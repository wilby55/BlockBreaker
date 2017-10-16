using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadLevel("Lose");
    }

    // Not used in here
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
    }
}
