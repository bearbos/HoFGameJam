using UnityEngine;
using System.Collections;

public class CircleGuyBehavior : MonoBehaviour {

    bool up_or_down, horizontal, target_right, is_a_target;
    int count = 0;
    int triangle_radius = 100;
    float delay_timer = 5.0f;

    // Use this for initialization
    void Start () {
        up_or_down = true;
        horizontal = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (is_a_target)
        {
            GetComponent<Animator>().SetBool("Warning", true);
            delay_timer -= Time.deltaTime;

            if (delay_timer < 0.0f)
            {
                GetComponent<Animator>().SetBool("Warning", false);
                if (horizontal)
                {
                    if (target_right)
                    {
                        transform.position = new Vector3(transform.position.x - .02f, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x + .02f, transform.position.y, transform.position.z);
                        
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
                    if (target_right)
                    {
                        transform.position = new Vector3(transform.position.x + .02f, transform.position.y + .02f, transform.position.z);
                    }
                    else transform.position = new Vector3(transform.position.x - .02f, transform.position.y + .02f, transform.position.z);
                    if (count == triangle_radius)
                        up_or_down = false;
                }

                else if (!up_or_down)
                {
                    if (target_right)
                    {
                        transform.position = new Vector3(transform.position.x + .02f, transform.position.y - .02f, transform.position.z);
                    }
                    else transform.position = new Vector3(transform.position.x - .02f, transform.position.y - .02f, transform.position.z);
                    if (count == triangle_radius)
                    {
                        up_or_down = true;
                        horizontal = true;
                    }
                }
                count++;

               


                if (target_right != true)
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
            if (transform.position.x < coll.GetComponent<Transform>().position.x)
            {
                target_right = true;
            }
            else
            {
                target_right = false;
            }

            is_a_target = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Warning", false);
            is_a_target = false;
            delay_timer = 5.0f;
        }
    }
}
