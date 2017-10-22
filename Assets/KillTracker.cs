using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using UnityEngine;

public class KillTracker : MonoBehaviour {
    public float kills;
    public float stage;
    public Sprite level2;
    public Sprite level3;
    public AudioClip alevel2;
    public AudioClip alevel3;
    public AudioClip bossMusic;
    public GameObject vine;
    public GameObject apple;
    public GameObject robot;
    public Transform t;
    private float boss;
    // Use this for initialization
    void Start () {
        kills = 0;
        stage = 1;
        boss = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(kills == 5 && stage<2)
        {
            stage++;
            transform.localScale = new Vector3((float)0.1, (float)0.1, transform.localScale.z);
            GetComponent<SpriteRenderer>().sprite = level2;
            gameObject.AddComponent<BoxCollider2D>().size = new Vector2(24,56);
            GetComponent<AudioSource>().clip = alevel2;
            GetComponent<AudioSource>().Play();
            GetComponent<Platformer2DUserControl>().projectile = vine;

            GetComponent<Health>().health = 20;
        }
        else if(kills == 15 && stage<3)
        {
            stage++;
            transform.localScale = new Vector3((float)0.2, (float)0.2, transform.localScale.z);
            GetComponent<SpriteRenderer>().sprite = level3;
            gameObject.AddComponent<BoxCollider2D>().size = new Vector2(24, 66);
            GetComponent<AudioSource>().clip = alevel3;
            GetComponent<AudioSource>().Play();
            GetComponent<Platformer2DUserControl>().projectile = apple;
            GetComponent<Health>().health = 30;
        }
        else if (kills == 20 && boss<1)
        {
            GameObject spawnedRobo = Instantiate(robot, t.position, t.rotation);
            
            boss = 1;
            GetComponent<AudioSource>().clip = bossMusic;
            GetComponent<AudioSource>().Play();
        }
	}
}
