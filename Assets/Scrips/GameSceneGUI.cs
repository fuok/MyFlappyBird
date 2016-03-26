using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneGUI : MonoBehaviour
{

	public Text text_score, text_highest_score;
	public Image img_game_over, img_get_ready;
	public Button btn_restart, btn_home;

	// Use this for initialization
	void Start ()
	{
		img_get_ready.gameObject.SetActive (true);
		img_game_over.gameObject.SetActive (false);
		btn_restart.gameObject.SetActive (false);
		btn_home.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		text_score.text = GameManager.score.ToString ();
		text_highest_score.text = GameManager.highest_score.ToString ();

		switch (GameManager.status) {
		case GameStatus.Waiting:

			break;
		case GameStatus.Playing:
			img_get_ready.gameObject.SetActive (false);
			break;
		case GameStatus.GameOver:
			img_game_over.gameObject.SetActive (true);
			btn_restart.gameObject.SetActive (true);
			btn_home.gameObject.SetActive (true);
			break;
		default:
			break;
		}

	}

	public void restartGame ()
	{
		switch (SceneManager.GetActiveScene ().name) {
		case "GameScene1":
			SceneManager.LoadScene ("GameScene1");
			break;
		case "GameScene2":
			SceneManager.LoadScene ("GameScene2");
			break;
		default:
			break;
		}
	}

	public void GoHome ()
	{
		SceneManager.LoadScene ("StartScene");
	}
}
