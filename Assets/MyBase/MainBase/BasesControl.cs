using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList {
	public GameObject   myObject;
	public int          objectCount = 0;
	public LinkedList   prev;
	public LinkedList   next;

	public LinkedList(GameObject gameObject, string isHeader) {
		myObject = gameObject;
		objectCount = 1;
		prev = null;
		next = null;
	}

	public LinkedList(GameObject gameObject) {
		myObject = gameObject;
		prev = null;
		next = null;
	}

	public void add(GameObject newGameObject) {
		LinkedList newNode = new LinkedList(newGameObject);

		this.objectCount++;
		newNode.next = this.next;
		newNode.prev = this;
		this.next = newNode;
	}

	public void update() {
		LinkedList  curr = this.next;
		LinkedList  next;

		while (curr != null) {
			next = curr.next;
			if (curr.myObject == null) {
				this.objectCount--;
				curr.prev.next = curr.next;
				curr.next.prev = curr.prev;
			}
			curr = next;
		}
	}

	public GameObject getNearestObject(GameObject gameObject) {
		GameObject	nearestObject;
		float		nearestDistance;
		float		distance;
		LinkedList	curr = this.next;

		nearestObject = this.myObject;
		nearestDistance = Vector3.Distance(nearestObject.transform.position, gameObject.transform.position);
		while (curr != null) {
			distance = Vector3.Distance(curr.myObject.transform.position, gameObject.transform.position);
			if (nearestDistance > distance) {
				nearestObject = curr.myObject;
				nearestDistance = distance;
			}
			curr = curr.next;
		}
		return (nearestObject);
	}
}

public class BasesControl : MonoBehaviour
{
	public LinkedList baseList;

    // Start is called before the first frame update
    void Start()
    {
        baseList = new LinkedList(gameObject, "isHeader");
    }
}
