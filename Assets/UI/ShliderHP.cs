using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShliderHP : MonoBehaviour
{
	private GameObject		Player;
	public TextMeshProUGUI	textHP;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
		textHP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = (Player.GetComponent<Ability>().HP + " / " + Player.GetComponent<Ability>().maxHP);
    }
}
