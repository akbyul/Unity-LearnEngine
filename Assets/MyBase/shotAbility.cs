using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotAbility : MonoBehaviour
{
	private GameObject	target;
	private bool		isFirstSet = true;
	private bool		isCollision = false;
	private Collider2D	beforeCollision;

	public int	speed;
	public int	attactDamage;

	public Animator	destroyAnimation;


    // Start is called before the first frame update
    void Start()
    {
        destroyAnimation.SetBool("isDestroyed", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// move shot
		if (target != null && isCollision == false) {
			Vector2 dir = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
			dir.Normalize();
			transform.Translate(dir * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		// shot�� �߻��ϴ� Turret�� ����Ǿ��ִ� target(nearest Enemy)�� ������.
		if (isFirstSet == true && other.gameObject.tag == "Base") {
			target = other.gameObject.transform.GetChild(0).gameObject.GetComponent<BasicAttack>().nearestEnemy;
			isFirstSet = false;
		}
		
		// shot�� Enemy�� �浹�� Damage���� ��, destroy shot
		if (other.gameObject.tag == "Enemy" && beforeCollision != other) {
			beforeCollision = other;
			isCollision = true;
			other.gameObject.GetComponent<EnemyAbility>().HP -= attactDamage;
			setDestroyAnimation();
		}
	}

	void setDestroyAnimation() {
		destroyAnimation.SetBool("isDestroyed", true);
	}
}
