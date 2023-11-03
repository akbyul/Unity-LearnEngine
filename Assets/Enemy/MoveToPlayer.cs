using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : EnemyCollision {

	public int	speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
	void Update() {
	
	}

    void FixedUpdate()
    {
		if (isPlayerCollision == false) {
			Vector2 dir = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
			dir.Normalize();
			transform.Translate(dir * speed * Time.deltaTime);
		}
	}
}
