using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
	public GameObject	player;
	public Transform	prefBuliding;
	private Button		button;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.Find("Player");
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
		Instantiate(prefBuliding, new Vector3(Mathf.Round(player.GetComponent<Transform>().position.x), Mathf.Round(player.GetComponent<Transform>().position.y + 2) , Mathf.Round(player.GetComponent<Transform>().position.z)), Quaternion.identity);
	}

}
