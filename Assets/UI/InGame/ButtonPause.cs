using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
	public void OnClickedPauseButton() {
		Time.timeScale = 0.0f;
	}

	public void OnClickedContinueButton() {
		Time.timeScale = 1.0f;
	}

	public void OnClickedExitButton() {
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("MainMenu");
	}
}
