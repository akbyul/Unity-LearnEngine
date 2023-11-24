using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{

	public Animator	fireTurretAttackAnimation;


	// Start is called before the first frame update
	void Start()
    {
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	void endAttack() {
		fireTurretAttackAnimation.SetBool("startAttack", false);
		transform.parent.gameObject.SetActive(false);
	}
}
