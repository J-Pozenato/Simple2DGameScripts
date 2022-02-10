using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour
{
    public Animator animator;
    public AudioClip attackSound;

    private bool readyToAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            animator.SetInteger("AnimState", 1);
            if (attackSound)
                AudioSource.PlayClipAtPoint(attackSound, transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (readyToAttack)
            {
                var explode = target.GetComponent<Explode>() as Explode;
                explode.OnExplode();
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        readyToAttack = false;
        animator.SetInteger("AnimState", 0);
    }

    void Attack()
    {
        readyToAttack = true;   
    }



}
