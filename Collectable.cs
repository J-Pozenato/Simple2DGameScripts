using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public AudioClip pickupSound;
    
    private Player player;
    private Meter meter;


    // Start is called before the first frame update
    void Start()
    {
        meter = GameObject.FindObjectOfType<Meter>();
        player = GameObject.FindObjectOfType<Player>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (pickupSound)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position) ;

                if (tag == "Artifact")
                    player.GetArtifact();

            Destroy(gameObject);
            meter.Refill();

        }
    }
}
