using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public Transform[] waypoints;
    public int currentwaypoint;
    public float speed = 5f;
    Transform targetwaypoint;
    private Animation anim;
	// Use this for initialization

    void Start()
    {
        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentwaypoint < this.waypoints.Length)
        {
            targetwaypoint = waypoints[currentwaypoint];
            walk();
        }
	}
    void walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetwaypoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, targetwaypoint.position, speed*Time.deltaTime);

        anim.Play("run");

        if(transform.position == targetwaypoint.position){
            currentwaypoint++;
            if(currentwaypoint > 4)
            {

                DestroyObject(this.gameObject);
                playerstats.health -= 1;
                return;
            }
            targetwaypoint = waypoints[currentwaypoint];
        }
    }
}
