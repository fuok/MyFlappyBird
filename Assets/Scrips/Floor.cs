using UnityEngine;
using System.Collections;

/// <summary>
/// 地面的运动速度
/// </summary>
public class Floor : MonoBehaviour
{

	public float moveSpeed;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
		if (this.gameObject.transform.position.x < -6.54) {
			this.gameObject.transform.Translate (new Vector2 (13.37f, 0));
		}
	}
}
