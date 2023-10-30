using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_heart : MonoBehaviour
{
	public bl_Joystick	js; // 조이스틱 오브젝트를 저장할 변수라고 생각하기.
	public float		speed; // 조이스틱에 의해 움직일 오브젝트의 속도.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update()
	{
		// 스틱이 향해있는 방향을 저장해준다.
		Vector3	dir = new Vector3(js.Horizontal, js.Vertical, 0);

		// Vector의 방향은 유지하지만 크기를 1로 줄인다. 길이가 정규화 되지 않을시 0으로 설정.
		dir.Normalize();

		// 오브젝트의 위치를 dir 방향으로 이동시킨다.
		transform.position += dir * speed * Time.deltaTime;
	}
}