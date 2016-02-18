using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public GameObject enemy,point1, point2;

    public float movementSpeed = 5, step, startSpeed;

    public bool isTouching = false;

    private bool goToPoint1 = true;

    public float timeRemaining = 5;

    private Vector3 location;

    public int rightPoint = 5, leftPoint = 5;
    
    // Use this for initialization
    void Start ()
    {
        startSpeed = movementSpeed;
        enemy.tag = "Enemy";
        step = movementSpeed * Time.deltaTime;
        
        Vector3 temp = new Vector3(enemy.transform.position.x + rightPoint, enemy.transform.position.y, enemy.transform.position.z);
        point1.transform.position = temp;
        
        temp = new Vector3(enemy.transform.position.x - leftPoint, enemy.transform.position.y, enemy.transform.position.z);
        point2.transform.position = temp;

        if (movementSpeed < 0)
        {
            movementSpeed = 0;
        }

        


    }

    // Update is called once per frame
    void Update ()
    {

        step = movementSpeed * Time.deltaTime;

        if (!isTouching)
        {


            if (goToPoint1)
            {
                enemy.transform.position = Vector3.MoveTowards(transform.position, point1.transform.position, step);
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy.GetComponent<SpriteRenderer>().flipX = true;
                if (point1.transform.position == enemy.transform.position)
                {
                    goToPoint1 = false;
                }
            }
            else
            {
                enemy.transform.position = Vector3.MoveTowards(transform.position, point2.transform.position, step);
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy.GetComponent<SpriteRenderer>().flipX = false;
                if (point2.transform.position == enemy.transform.position)
                {
                    goToPoint1 = true;
                }

            }
        }
        if (isTouching)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0 && timeRemaining > -3)
            {
                movementSpeed = 5;
                step = movementSpeed * Time.deltaTime;               

                enemy.transform.position = Vector3.MoveTowards(transform.position, location, step);
            }

           
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (enemy.transform.position.x < location.x)
        {
            enemy.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            enemy.GetComponent<SpriteRenderer>().flipX = false;
        }
        Vector3 vectorToTarget = location - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        if (enemy.GetComponent<SpriteRenderer>().flipX == false)
        {
            angle = -angle;
        }
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);

        location = coll.GetComponent<Transform>().transform.position;

        isTouching = true;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (timeRemaining < -3)
        {
            location = coll.GetComponent<Transform>().transform.position;
            timeRemaining = 5;
        }
        isTouching = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        timeRemaining = 5;
        movementSpeed = startSpeed;
        isTouching = false;
    }

}
