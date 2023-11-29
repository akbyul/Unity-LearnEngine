using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
	public GameObject[]		enemyList;
	public GameObject		nearestEnemy;

	public Transform		prefShot;
	public float			coolTime;

	private int		maxEnemyList = 50;
	private int		isPossibleShot = 0;
	private float	updateTime;

	// Start is called before the first frame update
	void Start()
    {
        enemyList = new GameObject[maxEnemyList];
		updateTime = coolTime;
    }

    // Update is called once per frame
    void Update()
    {
		// 적이 1명 이상이고, 쏠 준비가 됐을때(방향조절 완료일 때)
		if (isPossibleShot > 0 && customif() == true) {
			updateTime += Time.deltaTime;
			// 쿨타임이 다 찼을 때,
			if (updateTime >= coolTime) {
				turretAttack();
				updateTime -= coolTime;
			}
		} else {
			updateTime += Time.deltaTime;
			if (updateTime >= coolTime) {
				updateTime = coolTime;
			}
		}
	}

	protected virtual bool customif() {
		if (gameObject.transform.parent.GetChild(1).gameObject.GetComponent<TurretRotation>().readyToShot == true) {
			return (true);
		}
		return (false);
	}

	protected virtual void turretAttack() {
		Instantiate(prefShot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		// Enemy가 Turret의 공격범위 안에 들어오게 되면, Enemy List에 저장.
		if (other.gameObject.tag == "Enemy") {
			for (int i = 0; i < maxEnemyList; i++) {
				if (enemyList[i] == null) {
					enemyList[i] = other.gameObject;
					break ;
				}
			}
			// 처음으로 들어온 Enemy를 nearest enemy로 설정.
			if (isPossibleShot == 0) {
				nearestEnemy = other.gameObject;
			}
			isPossibleShot++;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		// Enemy가 범위를 빠져나갈 시, Enemy List에서 삭제.
		if (other.gameObject.tag == "Enemy") {
			isPossibleShot--;
			for (int i = 0; i < maxEnemyList; i++) {
				if (enemyList[i] == null) {
					continue ;
				}
				// 삭제 후 update nearest Enemy 
				if (enemyList[i] == other.gameObject) {
					enemyList[i] = null;
					nearestEnemy = getNearestEnemy();
					break ;
				}
			}
		}
	}

	// 가장 가까운 Enemy를 return
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
