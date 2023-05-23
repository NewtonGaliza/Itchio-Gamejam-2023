using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color color;

    [SerializeField] private float speed;

    private string _playerColor;
    public string playerColor
    {
        get { return _playerColor; }
        set { _playerColor = value; }
    }

    private Rigidbody2D rigidbody2D;
    [SerializeField] private float jumpForce;
    private bool isJumping;
    private bool doubleJump;
   
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerColor = "white";
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckScreenLimit();
        //Debug.Log(playerColor);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("GreenGround"))
        {
            spriteRenderer.color = Color.green;
            playerColor = "green";
        }
        else if(collider.CompareTag("BlueGround"))
        {
            spriteRenderer.color = Color.blue;
            playerColor = "blue";
        }

        if(collider.CompareTag("GreenGate") && playerColor == "green")
        {
            Debug.Log("MATCH GREEN");
        }
        else if(collider.CompareTag("BlueGate") && playerColor == "blue")
        {
            Debug.Log("MATHE BLUE");
        }

        if(collider.CompareTag("JokerGate"))
        {
            SceneManager.LoadScene("Level2");
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
            if(!isJumping)
            {
                rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;   
            }
            else
            {
                if(doubleJump)
                {
                    rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
        }

        if(collision.gameObject.tag == "Plataforma")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = true;
        }

        if(collision.gameObject.tag == "Plataforma")
        {
            this.transform.parent = null;
        }
    }

    private void CheckScreenLimit()
    {
        Vector2 currentPosition = this.transform.position;

        float halfWidth = Width / 2f;
        float halfHeight = Height / 2f;

        Camera camera = Camera.main;
        Vector2 underLeftLimit = camera.ViewportToWorldPoint(Vector2.zero); //(0,0)
        Vector2 upperRightLimit = camera.ViewportToWorldPoint(Vector2.one); //(1,1)

        float leftReferencePoint = currentPosition.x - halfWidth;
        float rightReferencePoint = currentPosition.x + halfWidth;

        if(leftReferencePoint < underLeftLimit.x)
        {
            this.transform.position = new Vector2(underLeftLimit.x + halfWidth, currentPosition.y);
        }
        else if(rightReferencePoint > upperRightLimit.x)
        {
             this.transform.position = new Vector2(upperRightLimit.x - halfWidth, currentPosition.y);
        }

        float upReferencePoint = currentPosition.y + halfHeight;
        float downReferencePoint = currentPosition.y - halfHeight;

        if(upReferencePoint > upperRightLimit.y)
        {
            this.transform.position = new Vector2(currentPosition.x, upperRightLimit.y - halfHeight);
        }
        else if(downReferencePoint < underLeftLimit.y)
        {
            this.transform.position = new Vector2(currentPosition.x, underLeftLimit.y + halfHeight);
        }
    }

    private float Width //largura
    {
        get
        { 
            Bounds bounds = this.spriteRenderer.bounds; 
            Vector3 size = bounds.size;
            return size.x;
        }
    }

    private float Height
    {
        get
        {
            Bounds bounds  = this.spriteRenderer.bounds;
            Vector2 size = bounds.size;
            return size.y;
        }
    }


}