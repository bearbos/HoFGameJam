using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField]
    GameObject MainCamera = null;
    int difficultySetting = 0;
    int MOVEMENTOPTION;
    [SerializeField]
    float oxygen = 10f;
    float totalOxygen = 10f;
    bool adjusted = true;
    float movementDistance = 1;
    float damageAmountFromShark = 0.0f;
    float damageAmountFromOctopus = 0.0f;
    float damageAmountFromTerrain = 0.0f;
    float fillPerSuccess = 1f;
    float continuousO2Drain = 0.015625f;
    float movex;
    float movey;
    float movementTimer = 0.0f;
    bool movementPressed = false;
    bool TimerSet = false;
    float tempInvulnTimer = 0f;
    float tempTime = 0;
    float tempTimeMover;

    int tempO2 = 0;

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
        difficultySetting = MainCamera.GetComponent<Persistent>().GetDifficulty();
        Debug.Log(difficultySetting);
        Debug.Log("difficulty");
        MOVEMENTOPTION = MainCamera.GetComponent<Persistent>().GetControls();
        Debug.Log(MOVEMENTOPTION);
        Debug.Log("Movement Type");
        tempO2 = (int)oxygen;

    }

    // Update is called once per frame
    void Update()
    {
        if (adjusted)
        {
                        Debug.Log("test00");
            Debug.Log(difficultySetting);
            switch (difficultySetting)
            {
                case 0:     // EASY
                    {
                        Debug.Log("test0");

                    }
                    break;
                case 1:     // MEDIUM
                    {
                        damageAmountFromShark = 1.0f;
                        damageAmountFromOctopus = 1.0f;
                        damageAmountFromTerrain = 1.0f;
                        fillPerSuccess = .75f;
                        continuousO2Drain = 0.0625f;
                        Debug.Log("test1");
                    }
                    break;
                case 2:     // HARD
                    {
                        damageAmountFromShark = 2.0f;
                        damageAmountFromOctopus = 2.0f;
                        damageAmountFromTerrain = 2.0f;
                        fillPerSuccess = .5f;
                        continuousO2Drain = 0.125f;
                        Debug.Log("test2");
                    }
                    break;
                default:
                    Debug.Log("test3");
                    break;
            }

            adjusted = false;

        }

        oxygen -= continuousO2Drain * Time.deltaTime;

        if ((int)oxygen < tempO2)
        {
            tempO2 = (int)oxygen;
            Debug.Log(oxygen);
            Debug.Log("Oxygen");
            Debug.Log(continuousO2Drain);
            Debug.Log(difficultySetting);
        }

        if (movementTimer > 0)
        {
            movementTimer -= Time.deltaTime;
        }
        if (tempInvulnTimer > 0)
        {
            tempInvulnTimer -= Time.deltaTime;
        }


        #region Editor
        //#if UNITY_EDITOR
        //        if (Input.anyKey != movementPressed)
        //        {
        //            movementPressed = !(movementPressed);
        //            TimerSet = false;
        //        }


        //        if (movementTimer <= 0 && movementPressed)
        //        {
        //            movex = Input.GetAxis("Horizontal");
        //            movey = Input.GetAxis("Vertical");
        //            if (movex > 0)
        //            {
        //                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        //            }
        //            if (movex < 0)
        //            {
        //                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        //            }
        //            if (movey > 0)
        //            {
        //                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        //            }
        //            if (movey < 0)
        //            {
        //                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        //            }
        //            if (TimerSet)
        //            {
        //                movementTimer = .25f;
        //            }
        //            else
        //            {
        //                movementTimer = .75f;
        //                TimerSet = true;
        //            }
        //        }


        //#endif 
        #endregion

        if (MOVEMENTOPTION == 0)
        {       // TOUCH


            if (Input.touchCount > 0)
            {
                Debug.Log(Input.GetTouch(0).position);
                Debug.Log("TOUCH");
                Debug.Log(transform.position);
                Debug.Log("PLAYER");

                Vector3 temp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Debug.Log(temp);
                Debug.Log("TOUCH");
                Debug.Log(transform.position);
                Debug.Log("PLAYER");
                float x = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x;
                float y = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y;
                x = x - transform.position.x;
                y = y - transform.position.y;

                if (movementTimer <= 0 && tempTimeMover <= Time.time)
                {

                    if (x > 1f && Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                        moveDirection = 2;
                    }
                    if (x < -1f && Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                        moveDirection = 6;
                    }
                    if (y > 1f && Mathf.Abs(y) > Mathf.Abs(x))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                        moveDirection = 0;
                    }
                    if (y < -1f && Mathf.Abs(y) > Mathf.Abs(x))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                        moveDirection = 4;
                    }

                    tempTimeMover = Time.time + 1f;

                    if (TimerSet)
                    {
                        tempTimeMover = tempTime + .25f;
                        movementTimer = .25f;
                    }

                    //else
                    //{
                    //    tempTimeMover = tempTime + 2f;
                    //    movementTimer = .75f;
                    //    TimerSet = true;
                    //}

                }


            }
        }
        //#else
        if (MOVEMENTOPTION == 1)
        {

            //ACCELEROMETER

            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            float z = Input.acceleration.z;


            //Debug.Log(x);
            //Debug.Log(y);
            //Debug.Log(z);



            if (movementTimer <= 0 && tempTimeMover <= Time.time)
            {

                if (x > .2f)
                {
                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                    moveDirection = 2;
                }
                if (x < -.2f)
                {
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                    moveDirection = 6;
                }
                if (y > .2f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    moveDirection = 0;
                }
                if (y < -.2f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                    moveDirection = 4;
                }

                tempTimeMover = Time.time + 1f;

                if (TimerSet)
                {
                    tempTimeMover = tempTime + .25f;
                    movementTimer = .25f;
                }

                //else
                //{
                //    tempTimeMover = tempTime + 2f;
                //    movementTimer = .75f;
                //    TimerSet = true;
                //}

            }
        }

        //#endif


    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Wall")
        {
            if (moveDirection == 2) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            if (moveDirection == 6) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            if (moveDirection == 0) transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            if (moveDirection == 4) transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
    }

    public float GetOxygen()
    {
        return oxygen;
    }
    public float GetTotalOxygen()
    {
        return totalOxygen;
    }

    public void TakeDamage()
    {
        oxygen -= 1;
        tempInvulnTimer = damageAmountFromShark;

    }

}
