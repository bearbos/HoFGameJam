using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    bool isPaused;

    [SerializeField]
    GameObject pauseMenuCanvas;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }



        if (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) == GameObject.FindGameObjectWithTag("Pause").transform.position)
        {
            isPaused = !isPaused;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            backToMenu();
        }
    }

    public void backToMenu()
    {
        //Destroy(PlayerStatsScript.stats.gameObject);
        Time.timeScale = 1f;
        GameObject tempCamera = GameObject.FindGameObjectWithTag("MainCamera");
        tempCamera.GetComponent<Persistent>().ResetScore();
        Application.LoadLevel("MainMenu");
    }

    public void resume()
    {
        isPaused = false;
    }

}
