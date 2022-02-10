using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    public float speed = .5f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(transform.localScale.x, 0) * speed;  
    }
}
