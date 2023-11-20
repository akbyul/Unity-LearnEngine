using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	public GameObject	Player;

	protected bool    isPlayerCollision = false;

	public float    collisionTime = 1f;
	private float   collisionUpdateTime = 0.0f;

	// Start is called before the first frame update
	void Start()
    {
		Player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void FixedUpdate() {
		if (isPlayerCollision == true) {
			collisionUpdateTime += Time.deltaTime;
			if (collisionUpdateTime >= collisionTime) {
				Player.GetComponent<Ability>().HP -= GetComponent<EnemyAbility>().attackDamage;
				collisionUpdateTime -= collisionTime;
			}
		} else {
			collisionUpdateTime = 1f;
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


}

