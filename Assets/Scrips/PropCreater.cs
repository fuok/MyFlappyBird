using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// 通过触发器生成新水管
/// </summary>
public class PropCreater : MonoBehaviour
{
	public GameObject propPrefabs, enemyPrefabs;

	void Start ()
	{
		//创建第一个
		if ("GameScene1".Equals (SceneManager.GetActiveScene ().name)) {
			GameObject.Instantiate (propPrefabs, new Vector3 (6f, 0.61f, 0), Quaternion.identity);
		} else if ("GameScene2".Equals (SceneManager.GetActiveScene ().name)) {
			GameObject.Instantiate (enemyPrefabs, new Vector3 (5.45f, 0.55f, 0), Quaternion.identity);
		} else if ("GameScene3".Equals (SceneManager.GetActiveScene ().name)) {
			GameObject.Instantiate (propPrefabs, new Vector3 (6.83f, 0.61f, 0), Quaternion.identity);
		}
	}

	void Update ()
	{
	
	}

	//控制复制敌鸟的频率
	private float mRate = 2.5f;

	void OnTriggerExit2D (Collider2D collider)//触发后复制水管
	{
		//mode 1
		if ("GameScene1".Equals (SceneManager.GetActiveScene ().name) && collider.tag.Equals ("Prop")) {//可以通过其他标签控制新的对象
			Vector3 v3 = new Vector3 (collider.transform.position.x + 3.0f, Random.Range (-1.7f, 2.3f), collider.transform.position.z);
//			GameObject.Instantiate (collider.transform.parent.gameObject, v3, collider.transform.rotation);//注意是parent,上下水管是整体
			GameObject.Instantiate (propPrefabs, v3, collider.transform.rotation);//也可以复制预设,避免克隆的名字越来越长
			//还可以用水管重用的方法,没必要反复创建销毁,,TODO
		}
		//mode 2 
		else if ("GameScene2".Equals (SceneManager.GetActiveScene ().name) && collider.tag.Equals ("Enemy")) {
			Vector3 v3 = new Vector3 (collider.transform.position.x + Mathf.Clamp (mRate, 0.2f, mRate), Random.Range (-2f, 3.5f), collider.transform.position.z);
			GameObject.Instantiate (enemyPrefabs, v3, collider.transform.rotation);
			//增加点难度...
			mRate -= 0.05f;
		}
		//mode 3
		else if ("GameScene3".Equals (SceneManager.GetActiveScene ().name) && collider.tag.Equals ("Prop")) {
			//mode 3的管子间距小一点
			Vector3 v3 = new Vector3 (collider.transform.position.x + 2.5f, Random.Range (-1.7f, 2.3f), collider.transform.position.z);
			GameObject.Instantiate (propPrefabs, v3, collider.transform.rotation);
		}

	}
}
