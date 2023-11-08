using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
	public Transform	pref;
	private Button		button;

	// Start is called before the first frame update
	void Start()
    {
		button = this.transform.GetComponent<Button>();
		if (button != null) {
			button.onClick.AddListener(build);
		}
	}

	// Update is called once per frame
	void Update()
    {
    }

	void build() {
		Instantiate(pref, new Vector3(0, 0, 0), Quaternion.identity);
	}

}
