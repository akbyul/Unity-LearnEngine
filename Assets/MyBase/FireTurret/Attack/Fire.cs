using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public int	firstDamage = 10;
	public int	damagePerSec = 5;
	
	private float	damageStack = 0.0f;
	private float	endDOTTime = 5.0f;
	private float	updateTime = 0.0f;
	private float	pivotTime = 0.0f;

	private bool	isMainDOT = false;

    // Start is called before the first frame update
    void Start()
    {
		int	countDOT = 0;

        transform.parent.gameObject.GetComponent<EnemyAbility>().damageAD(firstDamage);
		for (int i = 0; i < transform.parent.childCount; i++) {
			if (transform.parent.GetChild(i).gameObject.tag == "DOT") {
				countDOT++;
			}
		}
		if (countDOT == 1) {
			isMainDOT = true;
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		updateTime += Time.deltaTime;
        if (updateTime <= endDOTTime && isMainDOT == true) {
			pivotTime += Time.deltaTime;
			if (pivotTime >= 0.1f) {
				damageStack += (float)damagePerSec / 10;
				pivotTime -= 0.1f;
			}
			if (damageStack >= 1) {
				transform.parent.gameObject.GetComponent<EnemyAbility>().damageAD(1);
				damageStack -= 1;
			}
		} else if (updateTime > endDOTTime) {
			if (isMainDOT == true) {
				int	countDOT = 0;
				for (int i = 0; i < transform.parent.childCount; i++) {
					if (transform.parent.GetChild(i).gameObject.tag == "DOT") {
						countDOT++;
					}
					if (countDOT == 2) {
						transform.parent.GetChild(i).gameObject.GetComponent<Fire>().isMainDOT = true;
						break ;
					}
				}
			}
			Destroy(gameObject);
		}
    }
}
