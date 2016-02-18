using UnityEngine;
using System.Collections;


public class Persistent : MonoBehaviour
{
    private static Persistent something = null;
    int current_char = 0;
    public string current_word; 
    public static bool MOVEMENTOPTION = false;
    public static int SHARK = 0;
    public static int OCTOPUS = 1;
    public static int ANGLER = 2;
    public static int EASY = 0;
    public static int MEDIUM = 1;
    public static int HARD = 2;








[SerializeField]
    enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
    [SerializeField]
    Difficulty difficultySetting = Difficulty.MEDIUM;
    [SerializeField]
    int score = 0;

    // Use this for initialization
    void Start()
    {
        if (something == null)
        {
            something = this;
            DontDestroyOnLoad(something);
        }
        else
        {
            DestroyImmediate(this);
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (current_word == "")
        {
            current_word = current_word = GameObject.FindGameObjectWithTag("GameController").GetComponent<WordManager>().three_letter_word;
        }

    }

    public int GetDifficulty()
    {
        return (int)difficultySetting;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetDifficulty(int _IntegerForDifficulty)
    {
        if (_IntegerForDifficulty > 2 || _IntegerForDifficulty < 0)
        {
            return;
        }
        else
        {
            difficultySetting = (Difficulty)_IntegerForDifficulty;
        }
    }
    public bool UpdateScore()
    {
        int tempScore = score + 100;

        if (tempScore < 0 || tempScore < score)
        {
            return false;
        }

        score = tempScore;

        return true;
    }

    public bool CheckBubble(char[] bubble_char)
    {
        if (current_word.Length >= 3)
        {
            if (bubble_char[0] == current_word[current_char])
            {
                UpdateScore();
                current_char++;
                if (current_char == current_word.Length && current_word.Length < 7)
                {
                    if (current_word.Length == 3) current_word = GameObject.FindGameObjectWithTag("GameController").GetComponent<WordManager>().four_letter_word;
                    else current_word = GameObject.FindGameObjectWithTag("GameController").GetComponent<WordManager>().seven_letter_word;

                    current_char = 0;
                }
                else if (current_char == current_word.Length)
                {
                    //Level End.
                }
                return true;
            }
        }

        return false;
    }
}