using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towermanager : MonoBehaviour {
    public static towermanager instance;
    
    void Awake()
    {
        instance = this;
    }

    private turretStore turretToBuild;
    public GameObject panel;
    public GameObject standardturret;



 //   public void towerTobuild(GameObject turret)
  // {       turretToBuild = turret;
   //} 

    public void selectTurretToBuild(turretStore turret)
    {
        turretToBuild = turret;
    }

    public bool canBuild { get { return turretToBuild != null; } }

    public void buildTurretHere(node node){
        if(currency.curmoney < turretToBuild.cost){
            panel.SetActive(true);
            return;
        }
        currency.curmoney -= turretToBuild.cost;
        GameObject turret =  (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.offset, Quaternion.identity);
        node.turret = turret;
    }
}
