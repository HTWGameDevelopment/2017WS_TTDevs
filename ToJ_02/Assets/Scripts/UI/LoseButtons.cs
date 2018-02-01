using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtons : MonoBehaviour {

	public void Restart() {
		SceneManager.LoadScene ("level_01");
	}

	public void SelectLevel() {
		SceneManager.LoadScene ("LevelSelect");
	}


}
