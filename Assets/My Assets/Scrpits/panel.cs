using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour {

    public turretStore standardturret;
    public turretStore MGturret;
    public turretStore RLturret;


    towermanager towermanager;
	// Use this for initialization
	void Awake () {


		
	}

    void Start()
    {
        towermanager = towermanager.instance;
    }

    public void selectStandardTurret()
    {
        towermanager.selectTurretToBuild(standardturret);
    }

    public void selectMGTurret()
    {
        towermanager.selectTurretToBuild(MGturret);
    }

    public void selectRLturret()
    {
        towermanager.selectTurretToBuild(RLturret);
    }
}
