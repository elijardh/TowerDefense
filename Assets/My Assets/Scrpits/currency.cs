using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currency : MonoBehaviour {

    public static int curmoney;
    public int Money = 1000;
    public Text moneyUI;
    void Start()
    {
        curmoney = Money;
        moneyUI.text = curmoney.ToString();
    }

    void Update()
    {
        moneyUI.text = curmoney.ToString(); 
    }
}
