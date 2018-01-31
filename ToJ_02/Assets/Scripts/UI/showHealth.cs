using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHealth : MonoBehaviour {

    public static showHealth single;
    void Awake()
    {
        single = this;
    }

    private static int health = 0;
    private int creepCount;
    private string waveInformation;
    private int amount;
	public Text healthDisplay;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		health = PlayerStats.single.getHealth ();
        creepCount = PlayerStats.single.getDestroyedCreeps();
		healthDisplay = GetComponent<Text> ();
        healthDisplay.text = "Health left: " + health.ToString() + "\nCreeps destroyed: " + creepCount.ToString() + "/" + amount.ToString() + waveInformation;
		
	}
    public void setWaveInformation(string info,int number)
    {
        waveInformation = info;
        amount = number;
    }
}
