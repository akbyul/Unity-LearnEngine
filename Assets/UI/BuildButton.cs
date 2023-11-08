using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
	private Button	button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.transform.GetComponent<Button>();
		if (button != null) {
			button.onClick.AddListener(openBuildList);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void openBuildList() {
		gameObject.SetActive(false);
	}
}
