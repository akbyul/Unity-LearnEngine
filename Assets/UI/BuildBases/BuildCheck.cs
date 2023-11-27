using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCheck : MonoBehaviour
{
	public GameObject	player;
	public Transform    prefBuliding;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	public void Destroy() {
		GameObject.Find("CanvasInGame").transform.Find("BuildButton").gameObject.SetActive(true);
		Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
	}

	public void Build() {
		if (gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<CheckBuildLocation>().collisionCount == 0) {
			GameObject.Find("CanvasInGame").transform.Find("BuildButton").gameObject.SetActive(true);
			GameObject newInstance = Instantiate(prefBuliding, new Vector3(Mathf.Round(player.GetComponent<Transform>().position.x), Mathf.Round(player.GetComponent<Transform>().position.y + 2), Mathf.Round(player.GetComponent<Transform>().position.z)), Quaternion.identity).gameObject;
			GameObject.Find("MainBase").GetComponent<BasesControl>().baseList.add(newInstance);
			Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
		}
	}
}
