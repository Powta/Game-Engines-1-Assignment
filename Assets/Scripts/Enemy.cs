using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //Components
    private Rigidbody myRb;
    //Movmeent Variables
    public float moveSpeed;
    public float leftPos, rightPos; //enemy move left and right so I need left and right position
    private bool isGoingLeft=true;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Enemy Movemement
    private void Movement()
    {
        if(isGoingLeft) 
        {
            if (transform.position.x > leftPos)
            {
                myRb.velocity = new Vector3(-moveSpeed, myRb.velocity.y, myRb.velocity.z);
            }
            else
            {
                isGoingLeft = false;
            }
        }

        else
        {
            if (transform.position.x < rightPos)
            {
                myRb.velocity = new Vector3(moveSpeed, myRb.velocity.y, myRb.velocity.z);//move right
            }
            else
            {
                isGoingLeft = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
