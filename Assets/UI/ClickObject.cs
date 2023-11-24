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
		// 마우스 클릭 시
		if (Input.GetMouseButtonDown(0))
	#else
		// 터치 시
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

			// 마우스 클릭 위치를 카메라 스크린 월드포인트로 변경.
			Vector2 pos = Camera.main.ScreenToWorldPoint(m_vecMouseDownPos);

			// Raycast함수를 통해 Ray가 부딪치는 collider중 Layer가 Base인 경우에만 hit에 return.
			RaycastHit2D isHitBase = Physics2D.Raycast(pos, Vector2.zero, 0, 1 << LayerMask.NameToLayer("Base"));
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0);

			// 클릭한곳이 UI가 아닐 시,
			if (EventSystem.current.IsPointerOverGameObject() == false) {
				Instantiate(testCreation, new Vector3(0, 0, 0), Quaternion.identity);

				// base range 표시중, 다른곳을 클릭 시,
				if (hit != isHitBase && baseRange != null) {
					hideBaseRange(isHitBase);
				}

				// base 클릭 시,
				if (isHitBase.collider != null) {
					// 이미 다른 base range 표시중이면,
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
