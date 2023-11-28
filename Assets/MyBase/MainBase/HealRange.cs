using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRange : MonoBehaviour
{
	public GameObject	Player;

	public int	healAmount;
	public int	healCoolTime;
	
	private float	updateTime = 0.0f;
	private bool	isPossibleHeal = false;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
		if (updateTime >= healCoolTime) {
			updateTime = 0.0f;
			if (isPossibleHeal == true) {
				Player.GetComponent<PlayerAbility>().heal(healAmount);
			}
		} else {
			updateTime += Time.deltaTime;
		}

    }

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			isPossibleHeal = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			isPossibleHeal = false;
		}
	}
}
