using UnityEngine;
using System.Collections;

public class WordManager : MonoBehaviour {

    public GameObject[] letter_spawners;
    public string three_letter_word;
    public string four_letter_word;
    public string seven_letter_word;
    int[] used_numbers = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    // Use this for initialization
    void Start () {
        letter_spawners = GameObject.FindGameObjectsWithTag("Letter");

        bool result = GetComponent<DictionaryData>().Load();
        if (result)
        {
            three_letter_word = GetComponent<DictionaryData>().three_letter_words
                [Random.Range(0, GetComponent<DictionaryData>().three_letter_words.Length)];
            four_letter_word = GetComponent<DictionaryData>().four_letter_words
                [Random.Range(0, GetComponent<DictionaryData>().four_letter_words.Length)];
            seven_letter_word = GetComponent<DictionaryData>().seven_letter_words
                [Random.Range(0, GetComponent<DictionaryData>().seven_letter_words.Length)];

            for (int i = 0; i < 3; ++i)
            {
                int number = Random.Range(0, letter_spawners.Length);
                while (number == used_numbers[0] || number == used_numbers[1] || number == used_numbers[2])
                {
                    number++;
                    if (number >= letter_spawners.Length)
                        number = 0;
                }
                used_numbers[i] = number;
                char letter = three_letter_word[i];
                letter_spawners[number].GetComponent<LetterSpawn>().InstantiateLetter(letter);
            }
            for (int i = 0; i < 4; ++i)
            {
                int number = Random.Range(0, letter_spawners.Length);
                while (number == used_numbers[0] || number == used_numbers[1] || number == used_numbers[2] ||
                    number == used_numbers[3] || number == used_numbers[4] || number == used_numbers[5] || number == used_numbers[6])
                {
                    number++;
                    if (number >= letter_spawners.Length)
                        number = 0;
                }
                used_numbers[i + 3] = number;
                char letter = four_letter_word[i];
                letter_spawners[number].GetComponent<LetterSpawn>().InstantiateLetter(letter);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < 7; ++i)
        {
            if (i < 3)
                letter_spawners[used_numbers[i]].GetComponent<LetterSpawn>().InstantiateLetter(three_letter_word[i]);
            else
                letter_spawners[used_numbers[i]].GetComponent<LetterSpawn>().InstantiateLetter(four_letter_word[i - 3]);
        }
	}
}
