using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField]
    GameObject MainCamera;
    [SerializeField]
    int difficultySetting = 0;
    [SerializeField]
    float oxygen = 10f;
    [SerializeField]
    bool adjusted = true;
    [SerializeField]
    float movementDistance = 1;
    [SerializeField]
    float damageAmountFromShark = 0.0f;
    [SerializeField]
    float damageAmountFromOctopus = 0.0f;
    [SerializeField]
    float damageAmountFromTerain = 0.0f;
    [SerializeField]
    float fillPerSuccess = 1f;
    [SerializeField]
    float continuousO2Drain = 0.0f;
    float movex;
    float movey;
    [SerializeField]
    float movementTimer = 0.0f;
    [SerializeField]
    bool movementPressed = false;
    bool TimerSet = false;

    int moveDirection = -1;
    /*
        -1 = None
        0 = Up
        1 = Up Right
        2 = Right
        3 = Down Right
        4 = Down
        5 = Down Left
        6 = Left
        7 = Up Left
    */

    // Use this for initialization
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    
    }

    // Update is called once per frame
    void Update()
    {

        if (adjusted)
        {
            switch (difficultySetting)
            {
                case 0:     // EASY
                    {

                    }
                    break;
                case 1:     // MEDIUM
                    {
                        damageAmountFromShark = 1.0f;
                        damageAmountFromOctopus = 1.0f;
                        damageAmountFromTerain = 1.0f;
                        fillPerSuccess = .75f;
                        continuousO2Drain = 0.125f;
                    }
                    break;
                case 3:     // HARD
                    {
                        damageAmountFromShark = 2.0f;
                        damageAmountFromOctopus = 2.0f;
                        damageAmountFromTerain = 2.0f;
                        fillPerSuccess = .5f;
                        continuousO2Drain = 0.25f;
                    }
                    break;
                default:
                    break;
            }

            adjusted = false;

        }

        if (movementTimer > 0)
        {
            movementTimer -= Time.deltaTime;
        }
        if (Input.anyKey != movementPressed)
        {
            movementPressed = !(movementPressed);
            TimerSet = false;
        }
        
        
        if (movementTimer <= 0 && movementPressed)
        {
            movex = Input.GetAxis("Horizontal");
            movey = Input.GetAxis("Vertical");
            if (movex > 0)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                moveDirection = 2;
            }
            if (movex < 0)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                moveDirection = 6;
            }
            if (movey > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                moveDirection = 0;
            }
            if (movey < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                moveDirection = 4;
            }
            if (TimerSet)
            {
                movementTimer = .25f;
            }
            else
            {
                movementTimer = .75f;
                TimerSet = true;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Wall"))
        {
            if (moveDirection == 2) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            if (moveDirection == 6) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            if (moveDirection == 0) transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            if (moveDirection == 4) transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
    }
}
