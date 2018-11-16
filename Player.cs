using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
    // variables needed for dashing
    private Rigidbody2D rb;
    private float DashSpeed;
    private float DashTime;
    private int Direction;
    private int DashNumber;
    public GameObject ParticleEffect;
    //variabels for running
    public float RunSpeed;
    private float MoveInputX;
    private float MoveInputY;
    public float StopDistance;
    //variable for jumping
    private float JumpForce;
    private bool IsGrounded;
    public Transform GroundCheck;
    private float CheckRadius;
    public LayerMask WhatIsGround;
    public int JumpValue;
    private int JumpNumber;
    //i frame 
    private bool isDashing;
    //respawning
    private float StartPosX;
    private float StartPosY;
    //screen shake
    private ScreenShake MainCamera;
    
    void Start()
    {

        MainCamera = GameObject.Find("Main Camera").GetComponent<ScreenShake>();
        rb = GetComponent<Rigidbody2D>();
        DashSpeed = 25;
        DashTime = 0.15f;
        JumpNumber = 1;
        DashNumber = 1;
        isDashing = false;
        StartPosX = gameObject.transform.position.x;
        StartPosY = gameObject.transform.position.y;
        JumpForce = 6;
        CheckRadius = 0.2f;
        
    }


    void Update()
    {

        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);
   
        HandleMovement();
        HandleDash();
        handleIFrames();
    }

    void HandleDash()
    {

        if (Direction == 0)
        {
            // four directions
            //left

            if (Input.GetKey(KeyCode.LeftArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                Direction = 1;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();
                

            }
            //right
            else if (Input.GetKey(KeyCode.RightArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) &&!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                Direction = 2;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();
            }
                

            //up
            else if (Input.GetKey(KeyCode.UpArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                Direction = 3;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();
            }
            //down
            else if (Input.GetKey(KeyCode.DownArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                Direction = 4;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();

            }

            //diagonals
            //up right
            else if (Input.GetKey(KeyCode.UpArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) &&(Input.GetKey(KeyCode.RightArrow)))
            {
                Direction = 5;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();

            }
            //up left
            else if (Input.GetKey(KeyCode.UpArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) && (Input.GetKey(KeyCode.LeftArrow)))
            {
                Direction = 6;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();

            }
            //down right
            else if (Input.GetKey(KeyCode.DownArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) && (Input.GetKey(KeyCode.RightArrow)))
            {
                Direction = 7;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();

            }
            //down left
            else if (Input.GetKey(KeyCode.DownArrow) && DashNumber > 0 && Input.GetKeyDown(KeyCode.X) && (Input.GetKey(KeyCode.LeftArrow)))
            {
                Direction = 8;
                Instantiate(ParticleEffect, this.transform.position, Quaternion.identity);
                MainCamera.shakeCamera();

            }



        }
        else
        {
            if (DashTime <= 0)
            {
                Direction = 0;
                DashTime = 0.15f;
                rb.velocity = Vector2.zero;
            }
            else
            {
                DashTime -= Time.deltaTime;

                if (Direction == 1)
                {
                    rb.velocity = new Vector2(-1, 0) * DashSpeed;
                    DashNumber--;
                }
                else if (Direction == 2)
                {
                    rb.velocity = new Vector2(1, 0) * DashSpeed;
                    DashNumber--;
                }
                else if (Direction == 3)
                {
                    rb.velocity = new Vector2(0, 1) * DashSpeed;
                    
                    DashNumber--;
                }
                else if (Direction == 4)
                {
                    rb.velocity = new Vector2(0, -1) * DashSpeed;
                    
                    DashNumber--;
                }
                else if (Direction == 5)
                {
                    rb.velocity = new Vector2(1, 1) * DashSpeed;

                    DashNumber--;
                }
                else if (Direction == 6)
                {
                    rb.velocity = new Vector2(-1, 1) * DashSpeed;

                    DashNumber--;
                }
                else if (Direction == 7)
                {
                    rb.velocity = new Vector2(1, -1) * DashSpeed;

                    DashNumber--;
                }
                else if (Direction == 8)
                {
                    rb.velocity = new Vector2(-1, -1) * DashSpeed;

                    DashNumber--;
                }
            }
        }
    }

    void HandleMovement()
    {

        MoveInputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInputX * RunSpeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow) && rb.velocity.x <= StopDistance && IsGrounded == true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && rb.velocity.x >= -StopDistance && IsGrounded==true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.C) && JumpNumber > 0)
        {
            rb.velocity = new Vector2(0, 1) * JumpForce;
 
            JumpNumber--;
        }
        else if (Input.GetKeyDown(KeyCode.C) && JumpNumber == 0 && IsGrounded == true)
        {
            rb.velocity = new Vector2(0, 1) * JumpForce;
        }
       
        if (IsGrounded == true)
        {
            JumpNumber = 1;
            DashNumber = 1;

        }

    }

    void killPlayer()
    {
        transform.position = new Vector2(StartPosX, StartPosY);
        rb.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet") && isDashing==false)
        {
           
            killPlayer();
        }
        if (collision.tag.Equals("Death"))
        {

            killPlayer();
        }
    }

    void handleIFrames()
    {
        if (Direction != 0)
        {
            isDashing = true;
        }
        else
        {
            isDashing = false;
        }
    }

    

}
