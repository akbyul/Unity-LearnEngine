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
		} else if (other.gameObject.tag == "EnemyCollider") {
			currentCollision = other.transform.parent.gameObject;
		}
		if (currentCollision != null && isAreadyCollision(currentCollision) == false) {
			inputList(currentCollision);
			currentCollision.GetComponent<EnemyAbility>().HP -= transform.parent.gameObject.GetComponent<explosionShot>().explosionDamage;
			currentCollision = null;
		}
	}

	bool isAreadyCollision (GameObject currentCollision) {
		for (int i = 0; i < maxEnemyList; i++) {
			if (collisionList[i] == null) {
				break ;
			}
			if (collisionList[i] == currentCollision) {
				return (true);
			}
		}
		return (false);
	}

	void inputList (GameObject currentCollision) {
		for (int i = 0; i < maxEnemyList; i++) {
			if (collisionList[i] == currentCollision) {
				break ;
			}
			if (collisionList[i] == null) {
				Debug.Log(i);
				collisionList[i] = currentCollision;
				break ;
			}
		}
	}
}
