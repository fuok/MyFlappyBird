using UnityEngine;
using System.Collections;

/// <summary>
/// 水管的脚本,不停地向左移动
/// </summary>
public class Prop : MonoBehaviour
{
	public float moveSpeed;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.status == GameStatus.Playing) {
			this.transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
			if (this.gameObject.transform.position.x < -6.54) {
				Destroy (this.gameObject);
			}
		}
	}


}
