using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHealth : MonoBehaviour {

	private static int health = 0;
	Text healthDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		health = PlayerStats.single.getHealth ();
		healthDisplay = GetComponent<Text> ();
		healthDisplay.text = "Health left: " + health.ToString();
		
	}
}
