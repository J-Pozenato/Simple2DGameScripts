using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    private Material material;
    private SpriteRenderer spriteRenderer;
    private Color start;
    private Color end;
    private float t = 0.0f;


    // Start is called before the first frame update

    public void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        material = GetComponent<Renderer>().material;

        spriteRenderer = GetComponent<SpriteRenderer>();
        start = spriteRenderer.color;
        end = new Color(start.r, start.g, start.b, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        material.color = Color.Lerp(start, end, t/2);

        if (material.color.a <= 0.0)
            Destroy(gameObject);
    }
}
