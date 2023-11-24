using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
	private GameObject		currentCollision;
	private GameObject[]	collisionList;
	private int				maxEnemyList = 50;


	// Start is called before the first frame update
	void Start()
    {
		currentCollision = null;
		collisionList = new GameObject[maxEnemyList];
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			currentCollision = other.gameObject;
		} 
		if (currentCollision != null && inputList(currentCollision) == 1) {
			currentCollision.GetComponent<EnemyAbility>().HP -= transform.parent.gameObject.GetComponent<explosionShot>().explosionDamage;
			currentCollision = null;
		}
	}

	int inputList (GameObject currentCollision) {
		for (int i = 0; i < maxEnemyList; i++) {
			if (collisionList[i] == currentCollision) {
				return (0) ;
			}
			if (collisionList[i] == null) {
				collisionList[i] = currentCollision;
				return (1) ;
			}
		}
		return (0);
	}
}
