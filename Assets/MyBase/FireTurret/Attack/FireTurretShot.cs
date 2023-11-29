using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurretShot : MonoBehaviour
{
	public Transform	prefFire;

	public GameObject[]	enemyList;
	private int			maxEnemyList = 50;

	// Start is called before the first frame update
	void Start()
    {
		enemyList = new GameObject[maxEnemyList];
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy" && inputList(other.gameObject) == 1) {
			GameObject fire = Instantiate(prefFire, new Vector3(0, 0, 0), Quaternion.identity).gameObject;
			fire.transform.SetParent(other.transform);
		}
		if (gameObject.GetComponent<FireTurretAnimationControl>().endAnimation == true) {
			gameObject.GetComponent<FireTurretAnimationControl>().endAnimation = false;
			resetEnemyList();
		}
	}

	int inputList(GameObject enemy) {
		for (int i = 0; i < maxEnemyList; i++) {
			if (enemyList[i] == null) {
				enemyList[i] = enemy;
				return (1);
			}
			if (enemyList[i] == enemy) {
				return (0);
			}
		}
		return (0);
	}

	void resetEnemyList() {
		for (int i = 0; i < maxEnemyList; i++) {
			enemyList[i] = null;
		}
	}
}
