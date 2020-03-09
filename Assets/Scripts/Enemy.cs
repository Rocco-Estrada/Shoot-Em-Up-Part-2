using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject enemy;
	public GameObject bullet;
	private GameObject instBullet;

	public Animator animator;
	public AnimationClip explosion;
	public float seconds, startTime;

	public AudioClip fire;
	public AudioClip explode;
	public AudioSource speaker;

	void Start()
	{
		InvokeRepeating("EnemyFire", startTime, seconds);
	}

    void Update()
	{
        isFiring();
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Bullet"))
		{
            //explosion sound
			speaker.PlayOneShot(explode);

			animator.SetBool("isDestroyed", true);
			Destroy(collision.gameObject);
			Destroy(gameObject, explosion.length);
		}
	}

	void EnemyFire()
	{
        //fire sound
		speaker.PlayOneShot(fire);

		animator.SetBool("Fire", true);
		Vector3 firePos = enemy.transform.position;
		firePos.y -= 1.3f;
		instBullet = Instantiate(bullet, firePos, Quaternion.identity) as GameObject;
		Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
		instBulletRigidBody.AddForce(enemy.transform.up * -500);
	}

    void isFiring()
    {
        if(instBullet == null)
        {
			animator.SetBool("Fire", false);
		}
	}

}