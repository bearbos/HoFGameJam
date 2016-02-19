using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvaseHUDScript : MonoBehaviour {

    float fillPercent = 1;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Image FillBar;
    [SerializeField]
    string current_word;
    [SerializeField]
    GameObject[] Letters;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        fillPercent = Player.GetComponent<Player>().GetOxygen() / Player.GetComponent<Player>().GetTotalOxygen();

        FillBar.fillAmount = fillPercent;

        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Persistent>().current_word != current_word)
        {
            current_word = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Persistent>().current_word;

            Letters[2].GetComponentsInParent<Image>()[1].color = new Color(1.0f, 0.0f, 0.0f);
            Letters[3].GetComponentsInParent<Image>()[1].color = new Color(1.0f, 0.0f, 0.0f);
            Letters[4].GetComponentsInParent<Image>()[1].color = new Color(1.0f, 0.0f, 0.0f);
        }

        if (current_word.Length == 3)
        {
            Letters[2].GetComponent<Image>().sprite = Letters[2].GetComponent<LetterSpawn>().alphabet[current_word[0] - 'A'];
            Letters[3].GetComponent<Image>().sprite = Letters[3].GetComponent<LetterSpawn>().alphabet[current_word[1] - 'A'];
            Letters[4].GetComponent<Image>().sprite = Letters[4].GetComponent<LetterSpawn>().alphabet[current_word[2] - 'A'];


            Letters[0].GetComponent<Image>().enabled = false;
            Letters[0].GetComponentInParent<Image>().enabled = false;
            Letters[1].GetComponent<Image>().enabled = false;
            Letters[1].GetComponentInParent<Image>().enabled = false;
            Letters[5].GetComponent<Image>().enabled = false;
            Letters[5].GetComponentInParent<Image>().enabled = false;
            Letters[6].GetComponent<Image>().enabled = false;
            Letters[6].GetComponentInParent<Image>().enabled = false;
        }
    }

    public void ChangeColor(char[] found)
    {
        if (found[0] == current_word[0])
            Letters[2].GetComponentsInParent<Image>()[1].color = new Color(0.0f, 1.0f, 0.0f);
        else if (found[0] == current_word[1])
            Letters[3].GetComponentsInParent<Image>()[1].color = new Color(0.0f, 1.0f, 0.0f);
        else if (found[0] == current_word[2])
            Letters[4].GetComponentsInParent<Image>()[1].color = new Color(0.0f, 1.0f, 0.0f);
    }
}
