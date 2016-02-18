using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class DictionaryData : MonoBehaviour
{
    string filename = "Assets\\GJ_Dictionary.txt";

    public string[] three_letter_words;
    public string[] four_letter_words;
    public string[] seven_letter_words;

    // Use this for initialization
    void Start()
    {
        filename = "Assets\\GJ_Dictionary.txt";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Load()
    {
        string line;
        StreamReader theReader = new StreamReader(filename, Encoding.Default);
        for (int i = 0; i < 3; ++i)
        { 
            line = theReader.ReadLine();

            int num_words = int.Parse(line);

            line = theReader.ReadLine();

            int word_length = int.Parse(line);

            if (word_length == 3) three_letter_words = new string[num_words];
            else if (word_length == 4) four_letter_words = new string[num_words];
            else if (word_length == 7) seven_letter_words = new string[num_words];

            for (int j = 0; j < num_words; ++j)
            {
                line = theReader.ReadLine();

                if (word_length == 3) three_letter_words[j] = line;
                else if (word_length == 4) four_letter_words[j] = line;
                else if (word_length == 7) seven_letter_words[j] = line;
            }
        }

        theReader.Close();

        return true;

    }
}

