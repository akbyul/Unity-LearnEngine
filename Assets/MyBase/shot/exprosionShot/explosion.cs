using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
	private Collider2D  beforeCollision;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy" && beforeCollision != other) {
			beforeCollision = other;
			other.gameObject.GetComponent<EnemyAbility>().HP -= transform.parent.gameObject.GetComponent<explosionShot>().explosionDamage;
		}
	}
}
