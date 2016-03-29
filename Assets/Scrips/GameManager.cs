using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static int score = 0;
	public static int highest_score = 0;
	public static GameStatus status = GameStatus.None;
	// Use this for initialization
	void Start ()
	{
		//初始化
		status = GameStatus.Waiting;
		highest_score = PlayerPrefs.GetInt ("highestScore");
		score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

		switch (status) {
		case GameStatus.Waiting:
			Time.timeScale = 1;
			if (Input.anyKeyDown) {
				StartCoroutine (startPlaying ());
			}
			break;
		case GameStatus.Playing:
			Time.timeScale = 1;
			break;
		case GameStatus.Pause:
			Time.timeScale = 0;
			break;
		case GameStatus.GameOver:
			Time.timeScale = 0;
			break;
		default:
			Time.timeScale = 1;
			break;
		}
		//保存最高分
		if (score > highest_score) {
			highest_score = score;
			PlayerPrefs.SetInt ("highestScore", highest_score);
		}
	}

	//
	private IEnumerator startPlaying ()
	{
		yield return new WaitForEndOfFrame ();
		status = GameStatus.Playing;
	}
}
