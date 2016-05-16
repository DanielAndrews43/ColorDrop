using UnityEngine;
using System.Collections;

public class ColorsControl : MonoBehaviour {

	public GameObject colors;
	GameController gc;

	private float lastPos;
	private bool movement;

	void Start(){
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			//if (colors.GetComponent<BoxCollider2D> ().OverlapPoint (wp)) {
			movement = true;
			lastPos = wp.x;
			//}
		} else if (Input.GetMouseButton (0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//if (colors.GetComponent<BoxCollider2D> ().OverlapPoint (wp) && movement == false) {
			movement = true;
			lastPos = wp.x;
			//}
		}
	}

	void FixedUpdate(){
		if (movement) {
			Vector3 pos = colors.transform.position;
			pos.x += (Camera.main.ScreenToWorldPoint (Input.mousePosition).x - lastPos);
			colors.GetComponent<Transform> ().position = pos;
			movement = false;
		} else if (Input.GetAxis("Horizontal") > 0) {
			Vector3 pos = colors.transform.position;
			pos.x += 0.1f;
			colors.GetComponent<Transform> ().position = pos;
		} else if (Input.GetAxis("Horizontal") < 0) {
			Vector3 pos = colors.transform.position;
			pos.x -= 0.1f;
			colors.GetComponent<Transform> ().position = pos;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.tag == "SideTrigger") {
			if (coll.transform.position.x < 0) {
				gc.MoveColors (-1, this.gameObject.transform.position.x);
			} else {
				gc.MoveColors (1, this.gameObject.transform.position.x);
			}
		}
	}
}
