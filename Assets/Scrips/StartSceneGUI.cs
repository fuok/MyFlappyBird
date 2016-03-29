using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneGUI : MonoBehaviour
{

	public Button btnStart, btnExit, btnMode1, btnMode2, btnMode3;
	public GameObject panel1, panel2;
	// Use this for initialization
	void Start ()
	{
		panel2.SetActive (false);
		//UI初始化
		btnStart.onClick.AddListener (showModeSelect);
		btnExit.onClick.AddListener (ExitGame);
		btnMode1.onClick.AddListener (StartGame1);
		btnMode2.onClick.AddListener (StartGame2);
		btnMode3.onClick.AddListener (StartGame3);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown (KeyCode.Escape)) {
			if (panel2.activeSelf) {
				panel1.SetActive (true);
				panel2.SetActive (false);
			}
		}
	}

	private void showModeSelect ()
	{
		panel1.SetActive (false);
		panel2.SetActive (true);
	}

	private void StartGame1 ()
	{
//		Application.LoadLevel("MainScene");
		SceneManager.LoadScene ("GameScene1", LoadSceneMode.Single);
	}

	private void StartGame2 ()
	{
		SceneManager.LoadScene ("GameScene2", LoadSceneMode.Single);
	}

	private void StartGame3 ()
	{
		SceneManager.LoadScene ("GameScene3", LoadSceneMode.Single);
	}

	private void ExitGame ()
	{
		Application.Quit ();
	}
}
