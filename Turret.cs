using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
    private int Timer;
    public int TimerValue;
    private Vector2 Location1;
    private Vector2 Location2;
    [SerializeField] bool IsRight;
    // Use this for initialization
    void Start ()
    {
        Location1 = new Vector2(this.transform.position.x + 0.5f, this.transform.position.y);
        Location2 = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y);
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
            if (IsRight == true)
            {
                Instantiate(bullet, Location1, Quaternion.identity);
            }
            if (IsRight == false)
            {
                Instantiate(bullet, Location2, Quaternion.identity);
            }
            
            Timer = TimerValue;
        }
        Timer--;
    }
}
