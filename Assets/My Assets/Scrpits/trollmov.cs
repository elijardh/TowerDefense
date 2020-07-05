using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollmov : MonoBehaviour {

    public Transform[] waypoints;
    public int currentwaypoint;
    public float speed = 5f;
    Transform targetwaypoint;
    // Use this for initialization

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentwaypoint < this.waypoints.Length)
        {
            targetwaypoint = waypoints[currentwaypoint];
            walk();
        }
    }
    void walk()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetwaypoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, targetwaypoint.position, speed * Time.deltaTime);


        if (transform.position == targetwaypoint.position)
        {
            currentwaypoint++;
            if (currentwaypoint > 4)
            {
                playerstats.health -= 2;
                DestroyObject(this.gameObject);
                return;
            }
            targetwaypoint = waypoints[currentwaypoint];
        }
    }
}
