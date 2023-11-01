using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	GameObject	Player;
	Slider		mySlider;

	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.Find("Player");
		mySlider = GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update()
	{
		mySlider.maxValue = Player.GetComponent<Ability>().maxHP;
		mySlider.value = Player.GetComponent<Ability>().HP;
	}
}
