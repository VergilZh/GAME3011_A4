using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private TrailRenderer TR;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        TR = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.W) && moveDown != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, playerSpeed, 0);
            moveUp = true;
            moveDown = false;
            moveLeft = false;
            moveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && moveUp != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -playerSpeed, 0);
            moveDown = true;
            moveUp = false;
            moveLeft = false;
            moveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && moveRight != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-playerSpeed, 0, 0);
            moveLeft = true;
            moveRight = false;
            moveUp = false;
            moveDown = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && moveLeft != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(playerSpeed, 0, 0);
            moveRight = true;
            moveLeft = false;
            moveUp = false;
            moveDown = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacles")
        {
            gameObject.transform.position = new Vector3(-9, -3, 0);
            TR.Clear();
        }
        if (collision.tag == "Finish")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            moveRight = true;
            moveLeft = true;
            moveUp = true;
            moveDown = true;
            print("over");
        }
    }
}
