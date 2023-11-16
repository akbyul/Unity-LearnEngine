using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
	public int  HP;
	public int  maxHP;

	private int	temp = 0;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (temp != HP) {
			Debug.Log(HP);
			temp = HP;
		}
    }
}
