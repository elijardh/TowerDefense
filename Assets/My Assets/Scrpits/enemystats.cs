using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystats : MonoBehaviour {
    public int startHP = 200;
    private int health;
    public int worth = 50;
    public GameObject explosion;
    private bool isDead = false;
	// Use this for initialization
	void Awake () {
        health = startHP;
	}

    void Start()
    {

    }

    public void takedamge(int damage)
    {
        health -= damage;

        if (health <= 0 && !isDead)
        {
            die();
        }
    }

    void die()
    {
        isDead = true;
        currency.curmoney += worth;
        GameObject effect = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
