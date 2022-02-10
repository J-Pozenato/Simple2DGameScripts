using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    public float speed = 10f;
    public Vector2 maxVelocity = new Vector2(3, 5);
    public bool standing;
    public float jetSpeed = 15f;
    public float airSpeedMultiplier = .3f;
    public AudioClip leftFootSound;
    public AudioClip rightFootSound;
    public AudioClip thudSound;
    public AudioClip rocketSound;
    public bool artifact = false;


    private PlayerController controller;
    private Animator animator;
    private Rigidbody2D myRigidBody;


    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void PlayLeftFootSound()
    {
        if(leftFootSound)
            AudioSource.PlayClipAtPoint (leftFootSound, transform.position);
    }
    void PlayRightFootSound()
    {
        if (rightFootSound)
            AudioSource.PlayClipAtPoint(rightFootSound, transform.position);
    }

    void PlayRocketSound()
    {
        if(!rocketSound || GameObject.Find("RocketSound"))
            return;

        GameObject go = new GameObject("RocketSound");
        AudioSource aSrc = go.AddComponent<AudioSource>();
        aSrc.clip = rocketSound;
        aSrc.volume = 0.3f;
        aSrc.Play();

        Destroy(go, rocketSound.length) ;

    }
    
    
    void OnCollisionEnter2D(Collision2D target)
    {
        if(!standing)
        {
            var absVelX = Mathf.Abs(myRigidBody.velocity.x);
            var absVelY = Mathf.Abs(myRigidBody.velocity.y);

            if (absVelX <= .1f || absVelY <= .1f)
            {
                if(thudSound)
                    AudioSource.PlayClipAtPoint(thudSound, transform.position);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        var forceX = 0f;
        var forceY = 0f;

        var absVelX = Mathf.Abs(myRigidBody.velocity.x);
        var absVelY = Mathf.Abs(myRigidBody.velocity.y);

        if (absVelY < .2f)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }

        if (controller.moving.x != 0)
        {
            if (absVelX < maxVelocity.x)
            {
                forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);

                transform.localScale = new Vector3(forceX > 0 ? 1 : -1, 1, 1);
            }
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (controller.moving.y > 0)
        {
            PlayRocketSound();

            if (absVelY < maxVelocity.y)
                forceY = jetSpeed * controller.moving.y;

            animator.SetInteger("AnimState", 2);
        }
        else if (absVelY > 0)
        {
            animator.SetInteger("AnimState", 3);

        }
        myRigidBody.AddForce(new Vector2(forceX, forceY));
    }

    public void GetArtifact()
    {
        artifact = true;
    }

    public bool HasArtifact()
    {
        if(artifact)
            return true;
        return false;
    }

}
