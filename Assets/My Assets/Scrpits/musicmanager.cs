using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour {

    AudioSource audiodata;

	// Use this for initialization
	void Start () {
        audiodata = GetComponent<AudioSource>();
        audiodata.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
