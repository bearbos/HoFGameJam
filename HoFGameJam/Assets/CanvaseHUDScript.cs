using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvaseHUDScript : MonoBehaviour {

    float fillPercent = 1;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Image FillBar;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        fillPercent = Player.GetComponent<Player>().GetOxygen() / Player.GetComponent<Player>().GetTotalOxygen();

        FillBar.fillAmount = fillPercent;


    }
}
