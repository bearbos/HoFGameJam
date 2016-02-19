using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public GameObject menu, difficulty, controls;


    // Use this for initialization
    void Start () {
        menu.SetActive(true);
        difficulty.SetActive(false);
        controls.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void switchToHard()
    {

    }
    
    public void switchToDifficulty()
    {
        difficulty.SetActive(true);
        menu.SetActive(false);
    }

    public void switchToControls()
    {
        controls.SetActive(true);
        difficulty.SetActive(false);
    }
    public void startGame()
    {
        Application.LoadLevel(1);
    }
}
