using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
	public void OnClickedPauseButton() {
		Time.timeScale = 0.0f;
	}

	public void OnClickedContinueButton() {
		Time.timeScale = 1.0f;
	}
}
