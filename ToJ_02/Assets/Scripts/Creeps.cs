using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour {

	private int health = 100;
	private int rstnc_fire = 0;
	private int rstnc_water = 0;
	private int rstnc_wind = 0;
	private static float speed = 10f;
	private int creepType = 0;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static float getSpeed() {
		return speed;
	}
}
