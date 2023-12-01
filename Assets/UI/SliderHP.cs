using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderHP : MonoBehaviour
{
	private GameObject		Player;
	private TextMeshProUGUI	textHP;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
		textHP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textHP.text = (Player.GetComponent<PlayerAbility>().getHP() + " / " + Player.GetComponent<PlayerAbility>().getMaxHP());
    }
}
