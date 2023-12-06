using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : Ability
{
    // Start is called before the first frame update
    protected override void Start()
    {
		Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponentsInChildren<BoxCollider2D>()[1]);
		repair = 2;
		HP = maxHP;
    }
}
