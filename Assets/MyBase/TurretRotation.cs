using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
	public float	rotationSpeed;
	public bool		readyToShot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		GameObject	target = transform.parent.GetChild(0).gameObject.GetComponent<BasicAttack>().nearestEnemy;

		if (target != null) {
			float	fromAngle = transform.rotation.eulerAngles.z;
			float   toAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
			float	deltaAngle;
			
			// Euler 각도범위 -180 ~ 180
			if (fromAngle > 180) {
				fromAngle -= 360;
			} else if (fromAngle <= -180) {
				fromAngle += 360;
			}

			// 각도변화량(deltaAngle) 세팅
			if (0 < fromAngle - toAngle && fromAngle - toAngle <= 180) {
				deltaAngle = -1 * Time.deltaTime * rotationSpeed;
			} else {
				deltaAngle = Time.deltaTime * rotationSpeed;
			}

			if (Mathf.Abs(fromAngle - toAngle) > rotationSpeed / 5) {
				readyToShot = false;
				transform.rotation = Quaternion.Euler(0, 0, fromAngle + deltaAngle);
			} else {
				readyToShot = true;
			}
		}
	}
}
