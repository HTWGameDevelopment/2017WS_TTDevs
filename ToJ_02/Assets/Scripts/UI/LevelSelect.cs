using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	public static int levelNumber;

	public void PlayLevel1() {
		PlayerPrefs.SetString ("level", "Levels/level1.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel2() {
		PlayerPrefs.SetString ("level", "Levels/level2.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel3() {
		PlayerPrefs.SetString ("level", "Levels/level3.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel4() {
		PlayerPrefs.SetString ("level", "Levels/level4.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel5() {
		PlayerPrefs.SetString ("level", "Levels/level5.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel6() {
		PlayerPrefs.SetString ("level", "Levels/level6.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel7() {
		PlayerPrefs.SetString ("level", "Levels/level7.txt");
		SceneManager.LoadScene ("level_01");
	}

	public void PlayLevel8() {
		PlayerPrefs.SetString ("level", "Levels/level8.txt");
		SceneManager.LoadScene ("level_01");
	}
		
	public void Quit() {
		Debug.Log ("Quit!");
		Application.Quit ();
	}
}
