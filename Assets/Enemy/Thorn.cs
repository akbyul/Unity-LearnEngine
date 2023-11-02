using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
	public GameObject	Player;
	public int			attackDamage;

	private bool    isPlayerCollision = false;

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

}

