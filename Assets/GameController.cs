using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject colorsPrefab;
	public GameObject[] colorArray;
	float colorsPrefabWidth;

	public Text scoreText;
	private int score;

	public GameObject rightTrigger;
	public GameObject leftTrigger;

	void Start () {

		float targetSize = Vector3.Distance (Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, 0f)), Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, 0f)));
		float currentSize = colorsPrefab.GetComponent<BoxCollider2D>().size.x * colorsPrefab.transform.localScale.x;
		Vector3 newScale = colorsPrefab.transform.localScale;
		newScale.x = targetSize * newScale.x / currentSize;

		colorArray = new GameObject[3];

		colorArray [0] = (GameObject) Instantiate (colorsPrefab, new Vector3(0, -4.7f), Quaternion.identity);
		colorArray [0].transform.localScale = newScale;
		colorsPrefabWidth = colorArray [0].GetComponent<BoxCollider2D> ().size.x * colorArray [0].transform.lossyScale.x;
		colorArray [1] = (GameObject) Instantiate (colorsPrefab, new Vector3 (colorsPrefabWidth, -4.7f), Quaternion.identity);
		colorArray[2] = (GameObject) Instantiate (colorsPrefab, new Vector3 (-colorsPrefabWidth, -4.7f), Quaternion.identity);
		colorArray [1].transform.localScale = newScale;
		colorArray [2].transform.localScale = newScale;
	}

	public void AddPoint(){
		score++;
		scoreText.text = "" + score;
	}

	public void MoveColors(int side, float xCoord){

		float lowest = colorArray [0].transform.position.x;
		float highest = colorArray [0].transform.position.x;
		int indexLowest = 0;
		int indexHighest = 0;
		for (int i = 0; i < 3; i++) {
			if (colorArray [i].transform.position.x < lowest) {
				lowest = colorArray [i].transform.position.x;
				indexLowest = i;
			} else if (colorArray [i].transform.position.x > highest) {
				indexHighest = i;
				highest = colorArray [i].transform.position.x;
			}
		}

		if (side > 0 && lowest < leftTrigger.transform.position.x) {
			Vector3 pos = colorArray [indexLowest].transform.position;
			pos.x += colorsPrefabWidth * 3;
			colorArray [indexLowest].transform.position = pos;
		} else if(side < 0 && highest > rightTrigger.transform.position.x) {
			Vector3 pos = colorArray [indexHighest].transform.position;
			pos.x -= colorsPrefabWidth * 3;
			colorArray [indexHighest].transform.position = pos;
		}
	}
}
