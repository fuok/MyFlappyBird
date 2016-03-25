using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneGUI : MonoBehaviour {

	public Button btn_start,btn_exit;
	// Use this for initialization
	void Start () {
	//UI初始化
		btn_start.onClick.AddListener(StartGame);
		btn_exit.onClick.AddListener(ExitGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame()
	{
//		Application.LoadLevel("MainScene");
		SceneManager.LoadScene("GameScene1",LoadSceneMode.Single);
	}

	void ExitGame()
	{
		Application.Quit();
	}
}
