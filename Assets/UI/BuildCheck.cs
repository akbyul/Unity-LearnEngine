using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCheck : MonoBehaviour
{
	private Button      button;
	
	// Start is called before the first frame update
	void Start()
    {
		button = this.transform.GetComponent<Button>();
		if (button != null) {
			button.onClick.AddListener(Destroy);
		}
		if (buildButton == null) {
			Debug.Log("tset");
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	void Destroy() {
		int	size = gameObject.transform.childCount;

		Destroy(gameObject.transform.parent.gameObject);
	}
}
