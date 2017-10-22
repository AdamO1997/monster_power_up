using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health;
    private GameObject player;
    private Camera camera;
    private KillTracker killTracker;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        killTracker = player.GetComponent<KillTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            if(killTracker.stage <= 2)
            {
                player.transform.localScale = new Vector2((player.transform.localScale.x * (float)1.1), (player.transform.localScale.y * (float)1.1));
            }
            killTracker.kills += 1;

        }
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        health -= c.GetComponent<projectileController>().damage;
        GetComponent<AudioSource>().Play();
    }
}
