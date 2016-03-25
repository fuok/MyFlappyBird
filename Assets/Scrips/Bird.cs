using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
	public AudioSource ASFly;
	public AudioSource ASAddScore;
	public AudioSource ASDie;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.status == GameStatus.Playing) {
			this.gameObject.GetComponent<Rigidbody2D> ().isKinematic=false;
			this.gameObject.transform.Rotate(Vector3.forward*(-90)*Time.deltaTime);
			if (Input.anyKeyDown) {
				this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 5);//给小鸟向上的速度
//				this.gameObject.transform.Rotate(Vector3.forward*(90));
				this.gameObject.transform.eulerAngles=new Vector3(0,0,30);//每次飞行头朝上30度
				ASFly.Play ();
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		print ("bird die");
		ASDie.Play ();
		GameManager.status = GameStatus.GameOver; //游戏停止
	}

	void OnTriggerExit2D ()
	{
		GameManager.score++;
		ASAddScore.Play ();
		print ("得分:" + GameManager.score);
	}
}
