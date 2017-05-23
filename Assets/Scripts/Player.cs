﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	Spaceship spaceship;

	// Startメソッドをコルーチンとして呼び出す
	IEnumerator Start ()
	{
		spaceship = GetComponent<Spaceship> ();

		while (true) {
			spaceship.Shot (transform);

			// ショット音を鳴らす
			GetComponent<AudioSource>().Play();

			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	void Update ()
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");

		// 上・下
		float y = Input.GetAxisRaw ("Vertical");

		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;

		spaceship.Move (direction);
	}

	// ぶつかった瞬間に呼び出される
	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// レイヤー名がBullet (Enemy)の時は弾を削除
		if (layerName == "Bullet (Enemy)") {
			// 弾の削除
			Destroy (c.gameObject);
		}

		// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
		if( layerName == "Bullet (Enemy)" || layerName == "Enemy")
		{
			// 爆発する
			spaceship.Explosion();

			// プレイヤーを削除
			Destroy (gameObject);
		}
	}
}
