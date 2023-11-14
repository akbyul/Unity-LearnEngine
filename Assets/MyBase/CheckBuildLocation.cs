using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuildLocation : MonoBehaviour
{
	public int	collisionCount;

    // Start is called before the first frame update
    void Start()
    {
		collisionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Base" || other.gameObject.tag == "Enemy") {
			collisionCount++;
			transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Base" || other.gameObject.tag == "Enemy") {
			collisionCount--;
			if (collisionCount == 0)
				transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
		}
	}
}
