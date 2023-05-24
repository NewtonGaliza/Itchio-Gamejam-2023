using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   // [SerializeField] private Button buttonAbout;
  //  [SerializeField] private Button buttonMenu;

    private void Awake()
    {
        //buttonAbout.onClick.AddListener(LoadAboutScene);
      //  buttonMenu.onClick.AddListener(LoadStartScene);
    }

    void LoadAboutScene()
    {
        SceneManager.LoadScene("About");
    }

    void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

     
}
