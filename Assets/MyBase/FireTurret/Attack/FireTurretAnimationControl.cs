using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurretAnimationControl : MonoBehaviour
{
	public bool	isAttack = false;
	public bool	endAnimation = false;

	// Start is called before the first frame update
	void Start()
    {
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAttack == true) {
			for (int i = 0; i < 4; i++) {
				transform.GetChild(i).gameObject.GetComponent<AttackAnimation>().fireTurretAttackAnimation.SetBool("startAttack", true);
			}
			isAttack = false;
		}
    }
}
