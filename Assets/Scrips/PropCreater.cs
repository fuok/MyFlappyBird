using UnityEngine;
using System.Collections;

/// <summary>
/// 通过触发器生成新水管
/// </summary>
public class PropCreater : MonoBehaviour
{
	public GameObject prefabs;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerExit2D (Collider2D collider)//触发后复制水管
	{
//		print("bang!!!");
		if (collider.tag.Equals ("Prop")) {
			Vector3 v3 = new Vector3 (collider.transform.position.x + 2.5f, Random.Range (-1.7f, 2.3f), collider.transform.position.z);
//			GameObject.Instantiate (collider.transform.parent.gameObject, v3, collider.transform.rotation);//注意是parent，上下水管是整体
			GameObject.Instantiate (prefabs, v3, collider.transform.rotation);//也可以复制预设，避免克隆的名字越来越长
			//还可以用水管重用的方法，没必要反复创建销毁，,TODO
		}

	}
}
