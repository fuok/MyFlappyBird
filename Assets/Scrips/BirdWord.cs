using UnityEngine;
using System.Collections;

public class BirdWord : MonoBehaviour
{
	public GameObject mBird, mWord;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (Input.GetKeyDown(KeyCode.A)) {
//			mWord.SetActive(true);
//		}
		mWord.transform.position = new Vector3 (mBird.transform.position.x + 0.5f, mBird.transform.position.y + 1f, mBird.transform.position.z);
	}

	private void sawBigBoy ()
	{
		mWord.SetActive (true);
	}
}
