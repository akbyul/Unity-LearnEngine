using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour
{
	private Vector3		m_vecMouseDownPos;
	private GameObject	baseRange;
	private Color		newColor;

	public Transform    testCreation;

	// Start is called before the first frame update
	void Start()
    {
        
    }


	// Update is called once per frame
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

			// Raycast�Լ��� ���� Ray�� �ε�ġ�� collider�� Layer�� Base�� ��쿡�� hit�� return.
			RaycastHit2D isHitBase = Physics2D.Raycast(pos, Vector2.zero, 0, 1 << LayerMask.NameToLayer("Base"));
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0);

			// Ŭ���Ѱ��� UI�� �ƴ� ��,
			if (EventSystem.current.IsPointerOverGameObject() == false) {
				Instantiate(testCreation, new Vector3(0, 0, 0), Quaternion.identity);

				// base range ǥ����, �ٸ����� Ŭ�� ��,
				if (hit != isHitBase && baseRange != null) {
					hideBaseRange(isHitBase);
				}

				// base Ŭ�� ��,
				if (isHitBase.collider != null) {
					// �̹� �ٸ� base range ǥ�����̸�,
					if (baseRange != null) {
						hideBaseRange(isHitBase);
					}
						showBaseRange(isHitBase);
				}
			}
		}
	}

	void showBaseRange(RaycastHit2D isHitBase) {
		baseRange = isHitBase.transform.GetChild(0).gameObject;
		newColor = baseRange.GetComponent<SpriteRenderer>().color;
		newColor.a = 0.1f;
		baseRange.GetComponent<SpriteRenderer>().color = newColor;
	}

	void hideBaseRange(RaycastHit2D isHitBase) {
		newColor.a = 0.0f;
		baseRange.GetComponent<SpriteRenderer>().color = newColor;
		baseRange = null;
	}
}
