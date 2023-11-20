using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	Vector3 m_vecMouseDownPos;

	void Update() {
	#if UNITY_EDITOR
		// ���콺 Ŭ�� ��
		if (Input.GetMouseButtonDown(0))
	#else
		// ��ġ ��
		if (Input.touchCount > 0)
	#endif
		{
		#if UNITY_EDITOR
			m_vecMouseDownPos = Input.mousePosition;
		#else
			m_vecMouseDownPos = Input.GetTouch(0).position;
			if (Input.GetTouch(0).phase != TouchPhase.Began)
				return;
		#endif

			// ���콺 Ŭ�� ��ġ�� ī�޶� ��ũ�� ��������Ʈ�� ����.
			Vector2 pos = Camera.main.ScreenToWorldPoint(m_vecMouseDownPos);

			// Raycast�Լ��� ���� �ε�ġ�� collider�� hit�� ����.
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

			// � ������Ʈ���� �α����.
			if (hit.collider != null) {
				Debug.Log(hit.transform.gameObject);
			}
		}
	}


}
