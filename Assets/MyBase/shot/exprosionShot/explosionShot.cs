using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionShot : basicShotMovement {

	public int	explosionDamage;
	
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	protected override void shotCollisionControl(Collider2D other) {
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyCollider") {
			transform.GetChild(0).gameObject.SetActive(true);
			destroyAnimation.SetBool("isDestroyed", true);
		}
	}
}
