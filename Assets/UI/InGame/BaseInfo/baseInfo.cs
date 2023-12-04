using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class baseInfo : MonoBehaviour
{
	public GameObject	baseObject;
	public GameObject	buildButton;
	public Slider		mySlider;

	public TextMeshProUGUI	textName;

	// Update is called once per frame
	void FixedUpdate() {
		if (baseObject != null) {
			mySlider.maxValue = baseObject.GetComponent<BaseAbility>().getMaxHP();
			mySlider.value = baseObject.GetComponent<BaseAbility>().getHP();
			if (baseObject.GetComponent<BaseAbility>().getHP() <= 0) {
				this.baseObject = null;
				gameObject.SetActive(false);
				buildButton.SetActive(true);
			}
		}
	}

	public void setName() {
		switch (baseObject.name) {
			case ("MainBase") :
				setTextValue("기지", 36);
				break ;
			case ("ExplosionTurret(Clone)") :
				setTextValue("폭발 타워", 36);
				break;
			case ("FireTurret(Clone)") :
				setTextValue("불 타워", 36);
				break;
			default:
				setTextValue("Base", 36);
				break ;
		}
	}

	private void setTextValue(string name, int fontSize) {
		textName.text = name;
		textName.fontSize = fontSize;
	}
}
