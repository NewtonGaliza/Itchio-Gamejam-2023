using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button buttonAbout;

    private void Awake()
    {
        buttonAbout.onClick.AddListener(LoadAboutScene);
    }

    // Update is called once per frame
    void LoadAboutScene()
    {
        SceneManager.LoadScene("About");
    }

     
}
