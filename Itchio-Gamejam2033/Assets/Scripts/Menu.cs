using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button buttonMenu;

    private void Awake()
    {
        buttonMenu.onClick.AddListener(LoadStartScene);
    }

    void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
