using UnityEngine;
using System.Collections;

public class CircleGuyBehavior : MonoBehaviour {

    bool up_or_down;
    int count = 0;
    int spiral_radius = 20;
    float delay_timer = 2.5f;

    Vector3 target_position;

    // Use this for initialization
    void Start () {
        up_or_down = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (target_position != new Vector3(0.0f, 0.0f, 0.0f))
        {
            delay_timer -= Time.deltaTime;

            if (delay_timer < 0.0f)
            {
                // spinning corkscrew
                if (up_or_down)
                {
                    if (transform.position.x < target_position.x)
                    {
                        transform.position = new Vector3(transform.position.x + .1f, transform.position.y + .1f, transform.position.z);
                    }
                    else transform.position = new Vector3(transform.position.x - .1f, transform.position.y + .1f, transform.position.z);
                    if (count == spiral_radius)
                        up_or_down = false;
                }

                else if (!up_or_down)
                {
                    if (transform.position.x < target_position.x)
                    {
                        transform.position = new Vector3(transform.position.x + .1f, transform.position.y - .1f, transform.position.z);
                    }
                    else transform.position = new Vector3(transform.position.x - .1f, transform.position.y - .1f, transform.position.z);
                    if (count == spiral_radius)
                        up_or_down = true;
                }
                count++;

                if (count > spiral_radius) GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;


                if (transform.position.x < target_position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                Vector3 vectorToTarget = target_position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    angle = -angle;
                }
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);

                if (count > spiral_radius)
                {
                    count = 0;
                    spiral_radius -= 3;
                }

                if (spiral_radius <= 0)
                {
                    spiral_radius = 20;
                    target_position = new Vector3(0.0f, 0.0f, 0.0f);
                    delay_timer = 2.5f;
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
}
