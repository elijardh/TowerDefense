using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour {
    public GameObject largerEnemies;
    public GameObject obj;
    public Transform spawnpoint;
    public float timer = 5f;
    public float interval = 10f;
    public int wavenumber = 1;
    public Text wavecounterdown;
	// Use this for initialization

    void Awake()
    {

    }
	void Start () {
        wavecounterdown.text = timer.ToString() + " Seconds to First Wave";
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer <= 0){
            timer = interval;
            StartCoroutine(wavespawner());
        }
        timer -= Time.deltaTime;
        wavecounterdown.text = Mathf.Round(timer).ToString() + " Seconds to Next Wave";

		
	}
    void spawn()
    {
        if (wavenumber >= 5)
        {
            return;
        }
        
        Instantiate(obj, transform.position, transform.rotation);
    }
    IEnumerator wavespawner()
    {

        for (float i = 0; i < wavenumber; i++)
        {
            if (wavenumber > 7)
            {
                for (int h = 0; h < wavenumber; h++)
                {
                    spawnLarger();
                }
            }
            spawn();
            yield return new WaitForSeconds(0.5f);
        }
        wavenumber++;
    }

    void spawnLarger()
    {
        Instantiate(largerEnemies, transform.position, transform.rotation);
    }
}
