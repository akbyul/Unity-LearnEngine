using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList {
	public GameObject   myObject;
	public int          objectCount = 0;
	public LinkedList   next;
	public LinkedList   prev;

	public LinkedList(GameObject gameObject, string isHeader) {
		myObject = gameObject;
		objectCount = 1;
		next = null;
		prev = null;
	}

	public LinkedList(GameObject gameObject) {
		myObject = gameObject;
		next = null;
		prev = null;
	}

	public void add(GameObject newGameObject) {
		LinkedList newNode = new LinkedList(newGameObject);

		this.objectCount++;
		newNode.next = this.next;
		newNode.prev = this;
		Debug.Log(newNode.prev.myObject);
		if (this.next != null) {
			this.next.prev = newNode;
		}
		this.next = newNode;
	}

	public void delete(GameObject gameObject) {
		LinkedList  curr = this.next;
		LinkedList  next;

		while (curr != null) {
			next = curr.next;
			if (curr.myObject == gameObject) {
				this.objectCount--;
				curr.prev.next = curr.next;
				if (next != null) {
					next.prev = curr.prev;
				}
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

	public void printBaseList() {
		LinkedList	curr = this;
		
		while (curr != null) {
			Debug.Log(curr.myObject);
			curr = curr.next;
		}
		Debug.Log(curr.prev.myObject);
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
