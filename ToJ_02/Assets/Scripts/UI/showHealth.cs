using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHealth : MonoBehaviour {

	private static int health = 0;
    private static int creepCount;
	Text healthDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		health = PlayerStats.single.getHealth ();
        creepCount = PlayerStats.single.getDestroyedCreeps();
		healthDisplay = GetComponent<Text> ();
        healthDisplay.text = "Health left: " + health.ToString() + "\nCreeps destroyed: " + creepCount.ToString();
		
	}
}
