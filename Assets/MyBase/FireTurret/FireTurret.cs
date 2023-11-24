using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurret : BasicAttack {



	protected override bool customif() {
		return (true);
	}

	protected override void turretAttack() {
		transform.parent.GetChild(1).gameObject.SetActive(true);
		transform.parent.GetChild(1).gameObject.GetComponent<FireTurretAnimationControl>().isAttack = true;
	}

}
