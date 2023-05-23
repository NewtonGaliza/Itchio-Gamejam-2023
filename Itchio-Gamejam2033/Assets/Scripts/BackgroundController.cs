using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] backgrounds;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgrounds[0];
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(player.playerColor == "white")
        {
            spriteRenderer.sprite = backgrounds[1];
        }
        */
    }
}
