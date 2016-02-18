﻿using UnityEngine;
using System.Collections;

public class LetterSpawn : MonoBehaviour {

    char curr_letter;
    public Sprite[] alphabet;

	// Use this for initialization
	void Start () {
        curr_letter = '0';
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InstantiateLetter(char letter)
    {
        if (curr_letter == '0' || curr_letter == '\0')
        {
            if (letter != '0')
            {
                GetComponent<SpriteRenderer>().sprite = alphabet[letter - 'A'];
                curr_letter = letter;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //if (curr_letter == find_this)
        //{
        //  
        //}

        Destroy(this);
    }
}
