using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : Ability
{
	private GameObject	enemy;

	// Start is called before the first frame update
	protected override void Start()
    {
		enemy = gameObject;
		switch (enemy.name) {
			case "GreenSlime(Clone)" :
				setEnemyAbility(50, 0, 0, 0, 5);
				break ;
			case "EnemyDust(Clone)" :
				setEnemyAbility(20, 0, 0, 0, 10);
				break;
			default :
				setEnemyAbility(100, 0, 0, 0, 0);
				break;
		}
		HP = maxHP;
	}

	// Update is called once per frame
	protected override void FixedUpdate()
    {
		if (HP == maxHP) {
			transform.GetChild(0).gameObject.SetActive(false);
		} else {
			transform.GetChild(0).gameObject.SetActive(true);
		}
		if (HP <= 0) {
			Destroy(gameObject);
		}
    }

	private void setEnemyAbility(int maxHP, int repair, int adDef, int apDef, int attackDamage) {
		this.maxHP = maxHP;
		this.repair = repair;
		this.adDef = adDef;
		this.apDef = apDef;
		this.attackDamage = attackDamage;
	}
}
