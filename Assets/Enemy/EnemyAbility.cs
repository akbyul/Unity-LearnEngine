using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
	public int  HP;
	public int  maxHP;
	public int	attackDamage = 5;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (HP == maxHP) {
			transform.GetChild(0).gameObject.SetActive(false);
		} else {
			transform.GetChild(0).gameObject.SetActive(true);
		}
		if (HP <= 0) {
			Destroy(gameObject);
		}
    }
}
