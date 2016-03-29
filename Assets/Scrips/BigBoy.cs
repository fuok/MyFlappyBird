using UnityEngine;
using System.Collections;

public class BigBoy : MonoBehaviour
{
	public GameObject mReciever;
	private bool sent;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!sent && this.transform.position.x < 4.5f) {
			mReciever.SendMessage ("sawBigBoy");
			sent = true;
		}
	}
}
