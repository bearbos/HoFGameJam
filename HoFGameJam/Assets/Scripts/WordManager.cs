using UnityEngine;
using System.Collections;

public class WordManager : MonoBehaviour {

    public GameObject[] letter_spawners;
    public string[] three_letter_words;
    public int num_words;
    //public string four_letter_word;
    //public string seven_letter_word;
    [SerializeField]
    public char[] all_letters;
    int[] used_numbers = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};

    // Use this for initialization
    void Start () {

        num_words = Random.Range(3, 5);

        three_letter_words = new string[num_words];

        all_letters = new char[num_words * 3];
        letter_spawners = GameObject.FindGameObjectsWithTag("Letter");

        bool result = GetComponent<DictionaryData>().Load();
        if (result)
        {
            for (int i = 0; i < num_words; ++i)
            {
                three_letter_words[i] = GetComponent<DictionaryData>().three_letter_words
                    [Random.Range(0, GetComponent<DictionaryData>().three_letter_words.Length)];
            }
            //four_letter_word = GetComponent<DictionaryData>().four_letter_words
            //    [Random.Range(0, GetComponent<DictionaryData>().four_letter_words.Length)];
            //seven_letter_word = GetComponent<DictionaryData>().seven_letter_words
            //    [Random.Range(0, GetComponent<DictionaryData>().seven_letter_words.Length)];
            int index = 0;
            for (int i = 1; i <= num_words; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    int number = index;//Random.Range(0, letter_spawners.Length);
                    int num_checks = 0;
                    while (number == used_numbers[number] || number == used_numbers[number] || number == used_numbers[number])
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
                    used_numbers[number] = number;
                    char letter = three_letter_words[i - 1][j];
                    letter_spawners[number].GetComponent<LetterSpawn>().InstantiateLetter(letter);
                    all_letters[i - 1] = letter;
                    index++;
                }
            }
            //for (int i = 0; i < 4; ++i)
            //{
            //    int number = Random.Range(0, letter_spawners.Length);
            //    int num_checks = 0;
            //    while (number == used_numbers[0] || number == used_numbers[1] || number == used_numbers[2] ||
            //        number == used_numbers[3] || number == used_numbers[4] || number == used_numbers[5] || number == used_numbers[6])
            //    {
            //        num_checks++;
            //        number++;
            //        if (number >= letter_spawners.Length)
            //            number = 0;
            //
            //        if (num_checks > letter_spawners.Length)
            //            break;
            //    }
            //    used_numbers[i + 3] = number;
            //    char letter = four_letter_word[i];
            //    letter_spawners[number].GetComponent<LetterSpawn>().InstantiateLetter(letter);
            //    all_letters[i + 3] = letter;
            //}
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

}
