using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color color;

    [SerializeField] private float speed;

    private string playerColor;

    private Rigidbody2D rigidbody2D;
    [SerializeField] private float jumpForce;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Debug.Log(playerColor);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("DarkGround"))
        {
            spriteRenderer.color = Color.gray;
            playerColor = "gray";
        }
        else if(collider.CompareTag("LightGround"))
        {
            spriteRenderer.color = Color.white;
            playerColor = "white";
        }
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}