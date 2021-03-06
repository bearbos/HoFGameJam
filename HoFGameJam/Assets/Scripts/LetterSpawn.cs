﻿using UnityEngine;
using System.Collections;

public class LetterSpawn : MonoBehaviour {

    [SerializeField]
    char[] curr_letter = new char[2];
    public Sprite[] alphabet;
    bool enabled = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InstantiateLetter(char letter)
    {
            GetComponent<SpriteRenderer>().sprite = alphabet[letter - 'A'];
            curr_letter[0] = letter;
            enabled = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (enabled == true && coll.CompareTag("Player") && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Persistent>().CheckBubble(curr_letter))
        {
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvaseHUDScript>().ChangeColor(curr_letter);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().AddOxygen();
            Destroy(gameObject);
        }
    }
}
