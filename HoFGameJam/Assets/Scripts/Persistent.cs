using UnityEngine;
using System.Collections;

public class Persistent : MonoBehaviour
{
    private static Persistent something = null;



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
}