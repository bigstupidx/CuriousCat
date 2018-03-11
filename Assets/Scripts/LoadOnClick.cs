using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public static int releasedLevelStatic = 1;
	public int releasedLevel;
	public string nextLevel;

	void Awake () {
		if (PlayerPrefs.HasKey ("Level")) {
			releasedLevelStatic = PlayerPrefs.GetInt ("Level", releasedLevelStatic);
		}
	}

	public void ButtonNextLevel () {
		SceneManager.LoadScene (nextLevel);
		if (releasedLevelStatic <= releasedLevel) {
			releasedLevelStatic = releasedLevel;
			PlayerPrefs.SetInt ("Level", releasedLevelStatic);
		}
	}

	public void LoadSelectedLevel (int level) {
		SceneManager.LoadScene (level);
	}
}
