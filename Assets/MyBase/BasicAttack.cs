using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
	public GameObject[]		enemyList;
	public GameObject		nearestEnemy;
	public Transform		prefShot;
	public float			coolTime;

	private int		maxEnemyList = 20;
	private int		isPossibleShot = 0;
	private float	updateTime = 0f;

	// Start is called before the first frame update
	void Start()
    {
        enemyList = new GameObject[21];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (isPossibleShot > 0) {
			updateTime += Time.deltaTime;
			if (updateTime >= coolTime) {
 				Instantiate(prefShot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				updateTime -= coolTime;
			}
		} else {
			updateTime += Time.deltaTime;
			if (updateTime >= coolTime) {
				updateTime = coolTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Enemy�� Turret�� ���ݹ��� �ȿ� ������ �Ǹ�, Enemy List�� ����.
		if (other.gameObject.tag == "Enemy") {
			for (int i = 0; i < maxEnemyList; i++) {
				if (enemyList[i] == null) {
					enemyList[i] = other.gameObject;
					break ;
				}
			}
			// ó������ ���� Enemy�� nearest enemy�� ����.
			if (isPossibleShot == 0) {
				nearestEnemy = other.gameObject;
			}
			isPossibleShot++;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		// Enemy�� ������ �������� ��, Enemy List���� ����.
		if (other.gameObject.tag == "Enemy") {
			isPossibleShot--;
			for (int i = 0; i < maxEnemyList; i++) {
				if (enemyList[i] == null) {
					continue ;
				}
				// ���� �� update nearest Enemy 
				if (enemyList[i].name == other.name) {
					enemyList[i] = null;
					nearestEnemy = getNearestEnemy();
					break ;
				}
			}
		}
	}

	// ���� ����� Enemy�� return
	GameObject	getNearestEnemy() {
		int	temp = -1;

		for (int i = 0; i < maxEnemyList; i++) {
			if (enemyList[i] != null) {
				if (temp == -1) {
					temp = i;
				} else {
					if (Mathf.Abs(enemyList[temp].transform.position.x - transform.position.x) + Mathf.Abs(enemyList[temp].transform.position.y - transform.position.y)
						> Mathf.Abs(enemyList[i].transform.position.x - transform.position.x) + Mathf.Abs(enemyList[i].transform.position.y - transform.position.y)) {
						temp = i;
					}
				}
			}
		}
		if (temp != -1) {
			return (enemyList[temp]);
		} else {
			return (null);
		}
	}
}
