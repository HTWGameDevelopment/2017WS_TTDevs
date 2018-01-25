using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print (health);
		
	}

	public static void reduceHealth(int amount) {
		health = health - amount;
	}

	public static int getHealth() {
		return health;
	}
}
