using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.status == GameStatus.Playing) {
			this.transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
			if (this.gameObject.transform.position.x < -6.54) {
				Destroy (this.gameObject);
			}
		}
	}
}
