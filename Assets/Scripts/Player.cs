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
    }

    //Player Horizontal Movement
    private void Movement()
    {
        myRb.velocity = new Vector3(dirX, myRb.velocity.y, dirZ);
    }

}
