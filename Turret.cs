using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
    private int Timer;
    public int TimerValue;
    private Vector2 Location;
	// Use this for initialization
	void Start ()
    {
        Location = new Vector2(this.transform.position.x + 0.5f, this.transform.position.y);
        Timer = TimerValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        fireBullet();

    }

    void fireBullet()
    {
        if (Timer == 0)
        {
            Instantiate(bullet, Location, Quaternion.identity);
            Timer = TimerValue;
        }
        Timer--;
    }
}
