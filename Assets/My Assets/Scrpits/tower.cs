using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour {
    public Transform target;
    public int hpTarget;
    public Transform partToRotate;
    public string enemy = "enemy";
    public float range = 15f;
    public float speed = 2f;
    public float shootrate = 3f;
    private float countdown = 40f;
    public GameObject canon;
    public Transform location;

	// Use this for initialization
	void Start () {
		//InvokeRepeating("checkenemy", 0f, 1f);
	}

    void checkenemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy);
        float shortestdist = Mathf.Infinity;
        GameObject nearest = null;
        foreach(GameObject ene in enemies){
            float distance = Vector3.Distance(transform.position, ene.transform.position);
            if(distance < range){
                shortestdist = distance;
                nearest = ene;
            }
        }
        if (nearest != null && shortestdist < range)
        {
            target = nearest.transform;
        }
        else target = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerstats.ispaused == true)
        {
            return;
        }
        checkenemy();

		if(target == null){
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookat = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookat, Time.deltaTime * speed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);

        if (countdown <= 0f)
        {
            shoot();
            countdown = 30f;
        }
        countdown -= 1f;

	}
    void shoot()
    {
         
        GameObject bulletGo = (GameObject)Instantiate(canon, location.position, location.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();
        if (bullet != null)
        {
            bullet.seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); 
    }
}
