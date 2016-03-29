using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
	//	public AudioSource ASFly;
	//	public AudioSource ASAddScore;
	//	public AudioSource ASDie;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.status == GameStatus.Playing) {
			this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			this.gameObject.transform.Rotate (Vector3.forward * (-90) * Time.deltaTime);
			if (Input.anyKeyDown) {
				this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 5);//给小鸟向上的速度
//				this.gameObject.transform.Rotate(Vector3.forward*(90));
				this.gameObject.transform.eulerAngles = new Vector3 (0, 0, 30);//每次飞行头朝上30度
//				ASFly.Play ();
				AudioManagerS.PlayEffAudio ("sfx_wing");
			}
		}
	}

	void OnCollisionEnter2D ()
	{
//		print ("bird die");
//		ASDie.Play ();
		AudioManagerS.PlayEffAudio ("sfx_hit");
		GameManager.status = GameStatus.GameOver; //游戏停止
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("AddScoretrigger")) {
			GameManager.score++;
			AudioManagerS.PlayEffAudio ("sfx_point");
//			print ("得分:" + GameManager.score);
		}
	}
}
