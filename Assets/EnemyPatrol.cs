using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;
    private Rigidbody2D rb;
    private float counter;
    private Transform player;
    public GameObject bullet;
    public Transform launchPoint;
    public float fireRate;
    public float fireDelay;
    public bool hasFired;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        fireDelay = 0.5f;
        fireRate = 0;

	}
	
	// Update is called once per frame
	void Update () {
        player = GetComponentInChildren<PlayerFinder>().player.transform;
        if(fireRate >= fireDelay)
        {
            fireRate = 0;
            if (player != null)
            {
                Instantiate(bullet, launchPoint.position, launchPoint.rotation);
            }
        }
        else
        {
            fireRate += Time.deltaTime;
        }
        
        if (counter == 100)
        {
            moveRight = !moveRight;
            counter = 0;
        }
        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
        counter++;
	}
}
