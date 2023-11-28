using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : Ability
{
	// Start is called before the first frame update
	protected override void Start()
    {
		attackDamage = 50;
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
}
