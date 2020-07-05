using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilelauncher : MonoBehaviour {

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
    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Transform location4;
    public Transform location5;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("checkenemy", 0f, 1f);
    }

    void checkenemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy);
        float shortestdist = Mathf.Infinity;
        GameObject nearest = null;
        foreach (GameObject ene in enemies)
        {
            float distance = Vector3.Distance(transform.position, ene.transform.position);
            if (distance < range)
            {
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
    void Update()
    {
        if (playerstats.ispaused == true)
        {
            return;
        }
        checkenemy();

        if (target == null)
        {
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
        GameObject bulletGo1 = (GameObject)Instantiate(canon, location1.position, location1.rotation);
        GameObject bulletGo2 = (GameObject)Instantiate(canon, location2.position, location2.rotation);
        GameObject bulletGo3 = (GameObject)Instantiate(canon, location3.position, location3.rotation);
        GameObject bulletGo4 = (GameObject)Instantiate(canon, location4.position, location4.rotation);
        GameObject bulletGo5 = (GameObject)Instantiate(canon, location5.position, location5.rotation);

        bullet bullet = bulletGo.GetComponent<bullet>();
        bullet bullet1 = bulletGo1.GetComponent<bullet>();
        bullet bullet2 = bulletGo2.GetComponent<bullet>();
        bullet bullet3 = bulletGo3.GetComponent<bullet>();
        bullet bullet4 = bulletGo4.GetComponent<bullet>();
        bullet bullet5 = bulletGo5.GetComponent<bullet>();
        if (bullet != null)
        {
            bullet.seek(target);
        }
        if (bullet1 != null)
        {
            bullet1.seek(target);
        }
        if (bullet2 != null)
        {
            bullet2.seek(target);
        }
        if (bullet3 != null)
        {
            bullet3.seek(target);
        }
        if (bullet4 != null)
        {
            bullet4.seek(target);
        }
        if (bullet5 != null)
        {
            bullet5.seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
