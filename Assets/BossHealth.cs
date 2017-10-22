using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour {

    public float health;
    private GameObject player;
    private Camera camera;
    private KillTracker killTracker;
    public

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
            SceneManager.LoadScene("win");
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        health -= c.GetComponent<projectileController>().damage;
        GetComponent<AudioSource>().Play();
    }
}
