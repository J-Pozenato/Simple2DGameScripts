using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private GameObject go;

    public BodyPart bodyPart;
    public int totalParts = 5;
    public Transform PressRToRespawn;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            OnExplode();
        }
    }

    public void OnExplode()
    {
        Destroy(gameObject);
        
        var t = transform;

        for(int i = 0; i < totalParts;i++)
        {
            t.TransformPoint(0, -100, 0);
            BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-750, 750));
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(-750, 750));

            
        }

        Instantiate(PressRToRespawn, t.position, Quaternion.identity);
    }
}
