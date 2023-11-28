using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		int MaxHP = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyAbility>().getMaxHP();
		int HP = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyAbility>().getHP();

		GetComponent<RectTransform>().sizeDelta = new Vector2((float)HP / (float)MaxHP, 0.05f);
    }
}
