using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
	public GameObject	Player;
	public int			attackDamage;

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update()
    {
	
    }

	void OnCollisionStay2D(Collision2D collision) {
		if (collision.collider.gameObject.CompareTag("Player") && Player.GetComponent<Ability>().isCollision == false) {
			Player.GetComponent<Ability>().HP -= attackDamage;
			Player.GetComponent<Ability>().isCollision = true;
		}
	}
}

