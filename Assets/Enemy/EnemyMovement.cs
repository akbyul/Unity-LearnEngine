using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject	player;
	public float		collisionTime = 1f;

	private int			speed;
	private GameObject	enemy;
	private int         animationCount;

	private GameObject	collisionObject;
	private float		collisionUpdateTime = 0.0f;

	private GameObject	mainBase;


	// Start is called before the first frame update
	void Start()
    {
		enemy = gameObject;
		switch (enemy.name) {
			case "GreenSlime(Clone)":
				setMove(1, 4);
				break;
			case "EnemyDust(Clone)":
				setMove(2, 2);
				break;
			default:
				setMove(1, 1);
				break;
		}
		player = GameObject.Find("Player");
		mainBase = GameObject.Find("MainBase");
	}

	void FixedUpdate() {
		if (collisionUpdateTime >= collisionTime) {
			collisionUpdateTime = collisionTime;
		} else {
			collisionUpdateTime += Time.fixedDeltaTime;
		}

		if (collisionObject != null) {
			if (collisionUpdateTime >= collisionTime) {
				GetComponent<EnemyAbility>().attack(collisionObject);
				collisionUpdateTime -= collisionTime;
			}
		}

		GameObject	targetObject = getNearestObject(mainBase.GetComponent<BasesControl>().baseList.getNearestObject(gameObject));
		if (targetObject != null) {
			Vector2 dir = new Vector2(targetObject.transform.position.x - transform.position.x, targetObject.transform.position.y - transform.position.y);
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
		if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Base")) {
			collisionObject = collider.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Base")) {
			collisionObject = null;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player") || collision.collider.gameObject.CompareTag("Base")) {
			collisionObject = collision.collider.gameObject;
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player") || collision.collider.gameObject.CompareTag("Base")) {
			collisionObject = null;
		}
	}

	void EnemyWalk(int i) {
		if (i == 0) {
			transform.GetChild(this.animationCount).gameObject.SetActive(false);
		} else {
			transform.GetChild(i).gameObject.SetActive(false);
		}
		gameObject.transform.GetChild(i + 1).gameObject.SetActive(true);
	}

	GameObject getNearestObject(GameObject nearestBase) {
		if (nearestBase == null) return (null);
		float baseDistance = Vector3.Distance(nearestBase.transform.position, transform.position);
		float playerDistance = Vector3.Distance(player.transform.position, transform.position);
		if (baseDistance + 0.5 < playerDistance) {
			return (nearestBase);
		} else {
			return (player);
		}
	}

	private void setMove(int speed, int animationCount) {
		this.speed = speed;
		this.animationCount = animationCount;
	}
}
