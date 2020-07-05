using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour {
    public GameObject shop;
    public Color hoverColor;
    private Renderer rend;
    private Color startcolor;
    public GameObject turret;
    towermanager towermanager;

    public Vector3 offset;
    void Start()
    {
        towermanager = towermanager.instance;
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }

    void OnMouseDown()
    {
        shop.SetActive(true);
        if (turret != null)
        {
            Debug.Log("Can't build here");
        }
        else{
            towermanager.buildTurretHere(this);
        }
    }
}
 