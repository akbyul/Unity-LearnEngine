using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotAbility : MonoBehaviour
{
	private GameObject	target;
	private bool		isFirstSet = true;

	public int	speed;
	public int	attactDamage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// move shot
		if (target != null) {
			Vector2 dir = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
			dir.Normalize();
			transform.Translate(dir * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		// shot을 발사하는 Turret에 저장되어있는 target(nearest Enemy)을 가져옴.
		if (isFirstSet == true && other.gameObject.tag == "Base") {
			target = other.gameObject.transform.GetChild(0).gameObject.GetComponent<BasicAttack>().nearestEnemy;
			isFirstSet = false;
		}
		
		// shot이 Enemy와 충돌시 Damage입힌 후, destroy shot
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyAbility>().HP -= attactDamage;
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
