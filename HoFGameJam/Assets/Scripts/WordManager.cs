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
                int num_checks = 0;
                while (number == used_numbers[0] || number == used_numbers[1] || number == used_numbers[2])
                {
                    num_checks++;
                    number++;
                    if (number >= letter_spawners.Length)
                    {
                        number = 0;
                    }
                    if (num_checks > letter_spawners.Length)
                        break;
                }
                used_numbers[i] = number;
                char letter = three_letter_word[i];
                letter_spawners[number].GetComponent<LetterSpawn>().InstantiateLetter(letter);
            }
            for (int i = 0; i < 4; ++i)
            {
                int number = Random.Range(0, letter_spawners.Length);
                int num_checks = 0;
                while (number == used_numbers[0] || number == used_numbers[1] || number == used_numbers[2] ||
                    number == used_numbers[3] || number == used_numbers[4] || number == used_numbers[5] || number == used_numbers[6])
                {
                    num_checks++;
                    number++;
                    if (number >= letter_spawners.Length)
                        number = 0;

                    if (num_checks > letter_spawners.Length)
                        break;
                }
                used_numbers[i + 3] = number;
                char letter = four_letter_word[i];
                letter_spawners[number].GetComponent<LetterSpawn>().InstantiateLetter(letter);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

}
