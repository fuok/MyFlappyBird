using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainSceneGUI : MonoBehaviour {

	public Text text_score,text_highest_score;
	public Image img_game_over;
	public Button btn_restart,btn_home;

	// Use this for initialization
	void Start () {
		img_game_over.gameObject.SetActive(false);
		btn_restart.gameObject.SetActive(false);
		btn_home.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		text_score.text=GameManager.score.ToString();
		text_highest_score.text=GameManager.highest_score.ToString();
		if (GameManager.status==GameStatus.GameOver) {
			img_game_over.gameObject.SetActive(true);
			btn_restart.gameObject.SetActive(true);
			btn_home.gameObject.SetActive(true);
		}
	}

	public void startGame()
	{
		Application.LoadLevel("MainScene");
	}

	public void GoHome()
	{
		Application.LoadLevel("StartScene");
	}
}
