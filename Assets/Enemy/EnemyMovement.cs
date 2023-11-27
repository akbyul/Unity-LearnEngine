using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject	Player;
	public int			speed;
	public float		collisionTime = 1f;

	private string	collisionTag;
	private float   collisionUpdateTime = 0.0f;

	private GameObject	mainBase;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
		mainBase = GameObject.Find("MainBase");
	}

	void FixedUpdate() {
		if (collisionUpdateTime >= collisionTime) {
			collisionUpdateTime = collisionTime;
		} else {
			collisionUpdateTime += Time.deltaTime;
		}

		// Player와 충돌시
		if (collisionTag == "Player") {
			if (collisionUpdateTime >= collisionTime) {
				Player.GetComponent<Ability>().HP -= GetComponent<EnemyAbility>().attackDamage;
				collisionUpdateTime -= collisionTime;
			}
		}

		Vector2 dir = new Vector2(mainBase.GetComponent<BasesControl>().baseList.getNearestObject(gameObject).transform.position.x - transform.position.x, mainBase.GetComponent<BasesControl>().baseList.getNearestObject(gameObject).transform.position.y - transform.position.y);
		dir.Normalize();
		if (dir.x > 0) {
			transform.localEulerAngles = new Vector3(0, 0, 0);
		} else if (dir.x < 0) {
			transform.localEulerAngles = new Vector3(0, 180, 0);
			dir.x *= -1;
		}
		transform.Translate(dir * speed * Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			collisionTag = "Player";
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			collisionTag = "";
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player")) {
			collisionTag = "Player";
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player")) {
			collisionTag = "";
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
