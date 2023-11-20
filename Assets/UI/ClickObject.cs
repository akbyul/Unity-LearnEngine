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

			// Raycast함수를 통해 부딪치는 collider를 hit에 리턴.
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

			// 어떤 오브젝트인지 로그출력.
			if (hit.collider != null) {
				Debug.Log(hit.transform.gameObject);
			}
		}
	}


}
