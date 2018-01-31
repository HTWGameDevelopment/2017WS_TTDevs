using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LevelSelect : MonoBehaviour {
	public static int levelNumber;

	public void PlayLevel1() {
		PlayerPrefs.SetString ("level", "Levels/level1.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel2() {
		PlayerPrefs.SetString ("level", "Levels/level2.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel3() {
		PlayerPrefs.SetString ("level", "Levels/level3.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel4() {
		PlayerPrefs.SetString ("level", "Levels/level4.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel5() {
		PlayerPrefs.SetString ("level", "Levels/level5.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel6() {
		PlayerPrefs.SetString ("level", "Levels/level6.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel7() {
		PlayerPrefs.SetString ("level", "Levels/level7.txt");
		EditorSceneManager.LoadScene ("level_01");
	}

	public void PlayLevel8() {
		PlayerPrefs.SetString ("level", "Levels/level8.txt");
		EditorSceneManager.LoadScene ("level_01");
	}
		
	public void Quit() {
		Debug.Log ("Quit!");
		Application.Quit ();
	}
}
