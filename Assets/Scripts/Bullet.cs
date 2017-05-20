using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int speed = 10;
	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime = 5;

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
		// lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}
}
