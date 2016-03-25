using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 通过触发器生成新水管
/// </summary>
public class PropCreater : MonoBehaviour
{
	public GameObject propPrefabs,enemyPrefabs;
//	private GameObject mPrefabs;

	void Start ()
	{
//		print(SceneManager.GetActiveScene().name);
		//创建第一个
		if ("GameScene1".Equals(SceneManager.GetActiveScene().name)) {
			GameObject.Instantiate (propPrefabs, new Vector3(3.83f,0.61f,0), Quaternion.identity);
		}else if ("GameScene2".Equals(SceneManager.GetActiveScene().name)) {
//			GameObject.Instantiate (enemyPrefabs, new Vector3(3.83f,0.61f,0), Quaternion.identity);
		}
	}

	void Update ()
	{
	
	}

	void OnTriggerExit2D (Collider2D collider)//触发后复制水管
	{
//		print("bang!!!");
		if (collider.tag.Equals ("Prop")) {//可以通过其他标签控制新的对象
			Vector3 v3 = new Vector3 (collider.transform.position.x + 2.5f, Random.Range (-1.7f, 2.3f), collider.transform.position.z);
//			GameObject.Instantiate (collider.transform.parent.gameObject, v3, collider.transform.rotation);//注意是parent，上下水管是整体
			GameObject.Instantiate (propPrefabs, v3, collider.transform.rotation);//也可以复制预设，避免克隆的名字越来越长
			//还可以用水管重用的方法，没必要反复创建销毁，,TODO
		}else if (collider.tag.Equals ("Enemy")) {
			Vector3 v3 = new Vector3 (collider.transform.position.x + 2.5f, Random.Range (-2f, 3f), collider.transform.position.z);
			GameObject.Instantiate (enemyPrefabs, v3, collider.transform.rotation);
		}

	}
}
