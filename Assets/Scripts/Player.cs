using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player;

    public GameObject bullet;

    public Animator animator;
    public AnimationClip explosion;

    [SerializeField] private float amplitude = 0.25f;

    [SerializeField] private float speedBullet = 1000;

    private float velocityPlayer = 0;

    public AudioClip fire;
    public AudioClip move;
    public AudioClip explode;
    public AudioSource speaker;

    private bool isDestroyed = false;



    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        velocityPlayer = Input.GetAxis("Horizontal");
        Fire();
        if(isDestroyed == true)
            Application.LoadLevel("Credits");
    }

    void FixedUpdate()
    {
        MovePlayer(new Vector3(velocityPlayer, 0, 0), player);
    }

    void MovePlayer(Vector3 direction, Transform player)
    { 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            speaker.PlayOneShot(move);
        player.Translate(direction * amplitude);
    }

    void Fire()
    {

        Vector3 firePos = player.transform.position;
        firePos.y += 1f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speaker.PlayOneShot(fire);

            GameObject instBullet = Instantiate(bullet, firePos, Quaternion.identity) as GameObject;
            Rigidbody2D instBulletRigidBody = instBullet.GetComponent<Rigidbody2D>();
            instBulletRigidBody.AddForce(transform.up * speedBullet);
            //Set animator parameter
            animator.SetBool("Fire", true);
        }
        //if spacebar up fire == false
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Fire", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            speaker.PlayOneShot(explode);
            animator.SetBool("isDestroyed", true);
            Destroy(collision.gameObject);
            isDestroyed = true;
            Destroy(gameObject, explosion.length);
        }
    }

}

