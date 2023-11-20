using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerMoving : MonoBehaviour
{
	public GameObject	player;


    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.position = new Vector3(Mathf.Round(player.GetComponent<Transform>().position.x), Mathf.Round(player.GetComponent<Transform>().position.y + 2), Mathf.Round(player.GetComponent<Transform>().position.z));

	}
}
