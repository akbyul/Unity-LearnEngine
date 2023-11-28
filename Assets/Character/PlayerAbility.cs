using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : Ability
{
    // Start is called before the first frame update
    protected override void Start()
    {
		repair = 2;
		HP = maxHP;
    }
}
