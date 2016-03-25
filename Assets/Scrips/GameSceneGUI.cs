using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSceneGUI : MonoBehaviour {

	public Text text_score,text_highest_score;
	public Image img_game_over,img_get_ready;
	public Button btn_restart,btn_home;

	// Use this for initialization
	void Start () {
		img_get_ready.gameObject.SetActive(true);
		img_game_over.gameObject.SetActive(false);
		btn_restart.gameObject.SetActive(false);
		btn_home.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		text_score.text=GameManager.score.ToString();
		text_highest_score.text=GameManager.highest_score.ToString();

		switch (GameManager.status) {
		case GameStatus.Waiting:

			break;
		case GameStatus.Playing:
			img_get_ready.gameObject.SetActive(false);
			break;
		case GameStatus.GameOver:
			img_game_over.gameObject.SetActive(true);
			btn_restart.gameObject.SetActive(true);
			btn_home.gameObject.SetActive(true);
			break;
		default:
			break;
		}

	}

	public void startGame()
	{
		Application.LoadLevel("GameScene1");
	}

	public void GoHome()
	{
		Application.LoadLevel("StartScene");
	}
}
