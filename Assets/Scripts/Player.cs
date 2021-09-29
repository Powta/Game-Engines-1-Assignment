using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Components
    private Rigidbody myRb;

    //movement input
    private float dirX, dirZ; 

    //Movement Variables
    public float jumpForce;
    public float moveSpeed;
    private int numOfJumps = 0;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    //Player Input
    private void PlayerInput()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump"))//jump
        {
            if(numOfJumps>0)
            {
                Jump();
            }
        }
    }

    //Player Horizontal Movement
    private void Movement()
    {
        myRb.velocity = new Vector3(dirX, myRb.velocity.y, dirZ);
    }

    //Jump
    private void Jump()
    {
        myRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        numOfJumps--;//decrease number of jumps
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            numOfJumps = 1;
        }
    }
}
