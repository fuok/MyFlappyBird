using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float moveSpeed;
	private float mFlightRange;
	private bool flyUp;
	//保存初始位置属性
	private float mPosY{ set; get; }

	void Start ()
	{
		//上下飞行距离
		mFlightRange = 1f;
		//保存初始高度
		mPosY = this.transform.position.y;
	}

	void Update ()
	{
		if (GameManager.status == GameStatus.Playing) {
//			bool flyUp = true;
			if (this.transform.position.y > mPosY + mFlightRange) {
//				print ("到达上界:" + this.transform.position.y);
				flyUp = false;
			} else if (this.transform.position.y < mPosY - mFlightRange) {
//				print ("到达下界:" + this.transform.position.y);
				flyUp = true;
			}

			if (flyUp) {
				//向上飞
				this.transform.Translate (new Vector3 (Vector2.left.x, Vector2.up.y, 0) * moveSpeed * Time.deltaTime);
			} else {
				//向下飞
				this.transform.Translate (new Vector3 (Vector2.left.x, Vector2.down.y, 0) * moveSpeed * Time.deltaTime);
			}
				
			//销毁
			if (this.gameObject.transform.position.x < -6.54) {
				Destroy (this.gameObject);
			}
		}
	}
}
