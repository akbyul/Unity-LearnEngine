using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : Ability
{
	protected override void isDied() {
		Destroy(gameObject);
		GameObject.Find("MainBase").GetComponent<BasesControl>().baseList.delete(gameObject);
	}
}
