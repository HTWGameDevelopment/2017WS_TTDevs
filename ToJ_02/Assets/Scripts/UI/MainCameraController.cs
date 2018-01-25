using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xAxisValue = Input.GetAxisRaw("Horizontal");
		float zAxisValue = Input.GetAxisRaw("Vertical");
		float yAxisValue = Input.GetAxisRaw ("Zoom");
		if(Camera.current != null)
		{
			Camera.current.transform.Translate(new Vector3(xAxisValue, yAxisValue, zAxisValue), Space.World);
		}
		
	}
}
