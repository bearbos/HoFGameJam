using UnityEngine;
using System.Collections;

public class CircleGuyBehavior : MonoBehaviour {

    bool up_or_down, horizontal;
    int count = 0;
    int triangle_radius = 100;
    float delay_timer = 5.0f;

    Vector3 target_position;

    // Use this for initialization
    void Start () {
        up_or_down = true;
        horizontal = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (target_position != new Vector3(0.0f, 0.0f, 0.0f))
        {
            GetComponent<Animator>().SetBool("Warning", true);
            delay_timer -= Time.deltaTime;

            if (delay_timer < 0.0f)
            {
                GetComponent<Animator>().SetBool("Warning", false);
                if (horizontal)
                {
                    if (transform.position.x < target_position.x - 1.15f)
                    {
                        transform.position = new Vector3(transform.position.x + .02f, transform.position.y, transform.position.z);
                    }
                    else if (transform.position.x > target_position.x + 1.15f)
                    {
                        transform.position = new Vector3(transform.position.x - .02f, transform.position.y, transform.position.z);
                        
                    }
                    if (count == triangle_radius)
                    {
                        horizontal = false;
                        up_or_down = true;
                    }
                }
                // spinning corkscrew
                else if (up_or_down)
                {
                    if (transform.position.x < target_position.x - 1.15f)
                    {
                        transform.position = new Vector3(transform.position.x + .02f, transform.position.y + .02f, transform.position.z);
                    }
                    else if (transform.position.x > target_position.x + 1.15f) transform.position = new Vector3(transform.position.x - .02f, transform.position.y + .02f, transform.position.z);
                    if (count == triangle_radius)
                        up_or_down = false;
                }

                else if (!up_or_down)
                {
                    if (transform.position.x < target_position.x - 1.15f)
                    {
                        transform.position = new Vector3(transform.position.x + .02f, transform.position.y - .02f, transform.position.z);
                    }
                    else if (transform.position.x > target_position.x + 1.15f) transform.position = new Vector3(transform.position.x - .02f, transform.position.y - .02f, transform.position.z);
                    if (count == triangle_radius)
                    {
                        up_or_down = true;
                        horizontal = true;
                    }
                }
                count++;

               


                if (transform.position.x < target_position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                if (count > triangle_radius)
                {
                    count = 0;
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            target_position = coll.GetComponent<Transform>().position;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Warning", false);
            target_position = new Vector3(0.0f, 0.0f, 0.0f);
            delay_timer = 5.0f;
        }
    }
}
