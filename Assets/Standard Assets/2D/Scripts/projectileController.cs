using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    public GameObject player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(speed, rb.velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
