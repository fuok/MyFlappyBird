using UnityEngine;
using System.Collections;

public class Prop3Trigger : MonoBehaviour
{
	public GameObject mPropUp, mPropDown;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D col)
	{
//		print("撞到了:"+col.gameObject.name);
		if (col.gameObject.tag.Equals ("BigBoy")) {
			mPropUp.GetComponent<Rigidbody2D> ().isKinematic = false;
//			mPropUp.tag="BrokenProp";
			mPropDown.GetComponent<Rigidbody2D> ().isKinematic = false;
//			mPropDown.tag="BrokenProp";
		}
	}


}
