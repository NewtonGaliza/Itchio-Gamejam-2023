using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color color;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color.a = 255f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("DarkGround"))
        {
            //spriteRenderer.color = ;
        }

        if(collider.CompareTag("LightGround"))
        {
            spriteRenderer.color = Color.black;
        }
    }
}
