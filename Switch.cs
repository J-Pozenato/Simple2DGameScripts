using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public DoorTrigger[] doorTriggers;
    public bool sticky;

    private bool down;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        animator.SetInteger("AnimState", 1);
        down = true;

        foreach(DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null)
                trigger.Toggle(true);
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        if (sticky && down)
            return;
        
        animator.SetInteger("AnimState", 2);
        down = false;

        foreach (DoorTrigger trigger in doorTriggers)
        {
            if (trigger != null)
                trigger.Toggle(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = sticky ? Color.red : Color.green;
        foreach(DoorTrigger trigger in doorTriggers)
        {
            if(trigger != null)
               Gizmos.DrawLine(transform.position,trigger.door.transform.position);
        }
    }
}
