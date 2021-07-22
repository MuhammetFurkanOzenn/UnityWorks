using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool moveUp = true;
    public bool moveDown = true;
    public bool moveRight = true;
    public bool moveLeft = true;

    float speed = 55f;

    [SerializeField]
    public GameObject Box;

    // Start is called before the first frame update

    void Awake()
    {
        Debug.Log("Awake !");

    }

    void Start()
    {
        Debug.Log("Hello World !");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // CONTROL COMMANDS
        // ***
       
        if (Input.GetKey(KeyCode.D) && moveRight)
        {
            this.gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;                // HEAD'i X ekseninde döndür.

        }
        if (Input.GetKey(KeyCode.A) && moveLeft)
        {
            this.gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.W) && moveUp)
        {
            this.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.S) && moveDown)
        {
            this.gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);

        }
    }


    //COLLISION COMMANDS
    // ***
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("asdasda");
        if (collision.gameObject.name == "WallUp")                   //tag == "Wall")
        {
            moveUp = false;
        }

        if (collision.gameObject.name == "WallDown")
        {
            moveDown = false;
        }

        if (collision.gameObject.name == "WallRight")
        {
            moveRight = false;
            Debug.Log("moveRight");
        }

        if (collision.gameObject.name == "WallLeft")
        {
            moveLeft = false;
        }

        if (collision.gameObject.name == "Box")
        {
            Box.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("box");
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            moveUp = true;
            moveDown = true;
            moveRight = true;
            moveLeft = true;
        }
    }



}
