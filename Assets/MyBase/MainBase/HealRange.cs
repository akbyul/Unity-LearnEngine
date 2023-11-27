using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRange : MonoBehaviour
{
	public GameObject	Player;

	public int	HealAmount;
	public int	HealCoolTime;
	
	private float	updateTime = 0.0f;
	private bool	isPossibleHeal = true;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
		if (updateTime >= HealCoolTime) {
			updateTime = 0.0f;
			if (isPossibleHeal == true) {
				Player.GetComponent<Ability>().HP += HealAmount;
			}
		} else {
			updateTime += Time.deltaTime;
		}

    }

	void OnTriggerEnter2D(Collider2D collider) {
		isPossibleHeal = true;
	}

	void OnTriggerExit2D(Collider2D collider) {
		isPossibleHeal = false;
	}
}
