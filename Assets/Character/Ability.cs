using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
	public int		HP;
	public int		maxHP;
	

	public float	coolTime;
	private float	updateTime = 0.0f;

	public bool		isCollision = false;	
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
			this.HP += 2;
		} else {
			updateTime += Time.deltaTime;
		}

		if (HP < 0) {
			HP = 0;
		} else if (HP > maxHP) {
			HP = maxHP;
		}

		if (isCollision == true) {
			collisionUpdateTime += Time.deltaTime;
			if (collisionUpdateTime >= collisionTime) {
				isCollision = false;
				collisionUpdateTime = 0.0f;
			}
		}
    }
}
