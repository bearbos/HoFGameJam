using UnityEngine;
using System.Collections;

public class LetterSpawn : MonoBehaviour {

    char[] curr_letter = new char[2];
    public Sprite[] alphabet;

	// Use this for initialization
	void Start () {
        curr_letter[0] = '0';
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InstantiateLetter(char letter)
    {
        if (curr_letter[0] == '0' || curr_letter[0] == '\0')
        {
            GetComponent<SpriteRenderer>().sprite = alphabet[letter - 'A'];
            curr_letter[0] = letter;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player") && GameObject.FindGameObjectWithTag("Player").GetComponent<Persistent>().CheckBubble(curr_letter))
        {
            Destroy(this);
        }
    }
}
