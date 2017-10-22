using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    public float health;
    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("game over");
        }
        Debug.Log(health);
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log(c);
        health -= c.GetComponent<EnemyProjectileController>().damage;
    }
}
