using UnityEngine;
using System.Collections;

public class OctopusBehavior : MonoBehaviour {

    float degree_locaation;
    float agro_time = 0.0f;
    bool secondary_movement;
    Vector3 center_point;

	// Use this for initialization
	void Start () {
        center_point = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (agro_time > 0.0f) agro_time -= Time.deltaTime;

        else
        {
            GetComponent<Animator>().SetBool("Warning", false);
            GetComponent<Animator>().SetBool("Warning Left", false);

            degree_locaation += 1;

            Vector3 offset = new Vector3(Mathf.Sin(degree_locaation * Mathf.Deg2Rad) * 4.0f, Mathf.Cos(degree_locaation * Mathf.Deg2Rad) * 2.0f, 0.0f);

            transform.position = offset + center_point;

            if (transform.position.y > center_point.y + 0.1f)
            {
                GetComponent<Animator>().SetBool("Swim Right", true);
                GetComponent<Animator>().SetBool("Swim Left", false);
            }
            else if (transform.position.y < center_point.y - 0.1f)
            {
                GetComponent<Animator>().SetBool("Swim Left", true);
                GetComponent<Animator>().SetBool("Swim Right", false);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (transform.position.y > center_point.y + 0.2f)
        {
            GetComponent<Animator>().SetBool("Warning", true);
        }
        else if (transform.position.y < center_point.y - 0.2f)
        {
            GetComponent<Animator>().SetBool("Warning Left", true);
        }

        agro_time = 5.0f;
    }
}
