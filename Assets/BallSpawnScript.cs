using UnityEngine;
using System.Collections;

public class BallSpawnScript : MonoBehaviour {

	public GameObject[] balls;
	GameObject[] spawnedBalls;

	void Start(){
		InvokeRepeating ("MakeBall", 2f, 2f);
		spawnedBalls = new GameObject[10];
	}

	void MakeBall(){
		for (int i = 0; i < spawnedBalls.Length; i++) {
			if (spawnedBalls [i] == null) {
				spawnedBalls [i] = (GameObject) Instantiate (balls [Random.Range (0, balls.Length)], transform.position, Quaternion.identity);
				break;
			}
		}
	}
}
