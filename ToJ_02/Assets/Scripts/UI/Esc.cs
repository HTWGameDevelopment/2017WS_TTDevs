using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Esc : MonoBehaviour {
    public Button button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Continue();
        }
	}
    // Continues the game
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        if (GameMaster.single.waveStatus())
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
