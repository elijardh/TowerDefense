using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerstats : MonoBehaviour {

    public static int health;
    public GameObject menu;
    public static bool ispaused = false;

    public Text text;

    private int hp = 20;
	// Use this for initialization
	void Start () {
        menu.SetActive(false);
        health = hp;
        text.text = health.ToString() + "Lives";
	}
	
	// Update is called once per frame
	void Update () {
        text.text = health.ToString() + "Live(s)";

        if (health <= 0)
        {
            text.text = "0";
            ispaused = true;
            pause();
            menu.SetActive(true);

        }
		
	}

    public void pause (){

        Time.timeScale = 0;
}
}
