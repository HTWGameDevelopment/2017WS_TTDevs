using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame() {
		EditorSceneManager.LoadScene ("LevelSelect");
	}

	public void Quit() {
		Debug.Log ("Quit!");
		Application.Quit ();
	}
}
