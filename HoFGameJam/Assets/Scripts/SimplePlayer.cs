using UnityEngine;
using System.Collections;

public class SimplePlayer : MonoBehaviour {

    public GameObject player;
    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            this.GetComponent<SpriteRenderer>().flipX = false;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            this.GetComponent<SpriteRenderer>().flipX = true;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }
    }
}