using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGate : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(player.playerColor == "blue")
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                int nextScene = currentScene + 1;
                SceneManager.LoadScene(nextScene);
            }
        }
        
    }
}
