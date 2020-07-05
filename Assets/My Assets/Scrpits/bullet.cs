using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    private Transform target;
    public int damage; 
    public void seek(Transform _target) {
        target = _target;
    }
    public float speed = 50f;
    movement mov;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;
        if (dir.magnitude <= distance)
        {
            
            hitTarget();
            
            
        }

        transform.Translate(dir.normalized * distance, Space.World);
		
	}

    void hitTarget()
    {
        damageDealing(target);
        Destroy(gameObject);
    }

    void damageDealing(Transform enem)
    {
        enemystats en = enem.GetComponent<enemystats>();
        if (en != null)
        {
            en.takedamge(damage);
        }

    }
}
