using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject	Player;
	public int			speed;
	public float		collisionTime = 1f;

	private bool    isPlayerCollision = false;
	private float   collisionUpdateTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
	}

	void FixedUpdate() {
		if (collisionUpdateTime >= collisionTime) {
			collisionUpdateTime = collisionTime;
		} else {
			collisionUpdateTime += Time.deltaTime;
		}

		// Player와 충돌시 / 아닐시,
		if (isPlayerCollision == true) {
			if (collisionUpdateTime >= collisionTime) {
				Player.GetComponent<Ability>().HP -= GetComponent<EnemyAbility>().attackDamage;
				collisionUpdateTime -= collisionTime;
			}
		} else {
			Vector2 dir = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
			dir.Normalize();
			if (dir.x > 0) {
				transform.localEulerAngles = new Vector3(0, 0, 0);
			} else if (dir.x < 0) {
				transform.localEulerAngles = new Vector3(0, 180, 0);
				dir.x *= -1;
			}
			transform.Translate(dir * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			isPlayerCollision = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			isPlayerCollision = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player")) {
			isPlayerCollision = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player")) {
			isPlayerCollision = false;
		}
	}

	void GreenSlimeWalk(int i) {
		if (i == 0) {
			transform.GetChild(4).gameObject.SetActive(false);
		} else {
			transform.GetChild(i).gameObject.SetActive(false);
		}
		gameObject.transform.GetChild(i + 1).gameObject.SetActive(true);
	}
}
