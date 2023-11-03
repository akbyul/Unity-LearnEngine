using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	public GameObject	Player;
	public int			attackDamage;

	protected bool    isPlayerCollision = false;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update() {
		if (isPlayerCollision == true && Player.GetComponent<Ability>().isPossibleCollision == true) {
			Player.GetComponent<Ability>().HP -= attackDamage;
			Player.GetComponent<Ability>().isPossibleCollision = false;
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

