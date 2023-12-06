using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAlpha : MonoBehaviour
{
	private Image	myImage;

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
		myImage.alphaHitTestMinimumThreshold = 0.1f;
    }

	public void test() {
		Debug.Log(myImage.alphaHitTestMinimumThreshold);
	}
}
