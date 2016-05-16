using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {

	GameController gc;

	void Start(){
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		Destroy (coll.gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll){
		Destroy (coll.collider.gameObject);
		gc.AddPoint ();
	}
}
