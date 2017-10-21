using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;

    int maxHits;
    int timesHit;
    LevelManager levelManager;
    bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = this.tag == "Breakable";
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if(isBreakable)
        {
            breakableCount++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            print("breakable count: " + breakableCount);
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
