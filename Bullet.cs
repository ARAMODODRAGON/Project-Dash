using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int speed;
    private Rigidbody2D rb;
    public Bullet(int inputSpeed, bool isRight)
    {
        speed = inputSpeed;
        if (isRight == true) { speed = -speed; }
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();

    }

    

    void moveBullet()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
        {
            Destroy(gameObject);
            
        }


    }
}
