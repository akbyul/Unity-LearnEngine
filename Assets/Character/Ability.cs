using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
	public int	HP;
	public int	maxHP;
	public int	heal;
	

	public float	coolTime;
	private float	updateTime = 0.0f;

	public bool		isPossibleCollision = true;	
	public float	collisionTime;
	private float	collisionUpdateTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTime >= coolTime) {
			updateTime = 0.0f;
			this.HP += heal;
		} else {
			updateTime += Time.deltaTime;
		}

		if (HP < 0) {
			HP = 0;
		} else if (HP > maxHP) {
			HP = maxHP;
		}

		if (isPossibleCollision == false) {
			collisionUpdateTime += Time.deltaTime;
			if (collisionUpdateTime >= collisionTime) {
				isPossibleCollision = true;
				collisionUpdateTime = 0.0f;
			}
		}
    }
}
