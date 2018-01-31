using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour {

	public void LevelSelect() {
		SceneManager.LoadScene ("LevelSelect");
	}

	public void NextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
