using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LoseButtons : MonoBehaviour {

	public void Restart() {
		EditorSceneManager.LoadScene ("level_01");
	}

	public void SelectLevel() {
		EditorSceneManager.LoadScene ("LevelSelect");
	}


}
