using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : Ability
{
	private GameObject	mainBase;

	protected override void Start() {
		mainBase = GameObject.Find("MainBase");
		HP = maxHP;
	}

	protected override void isDied() {
		mainBase.GetComponent<BasesControl>().baseList.delete(gameObject);
		if (gameObject == mainBase) destroyMainBase();
		else {
			Destroy(gameObject);
		}
	}

	private void destroyMainBase() {
		Time.timeScale = 0.0f;
	}
}
