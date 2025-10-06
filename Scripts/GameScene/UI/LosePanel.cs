using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : PanelController<LosePanel>
{
    public Button againButton;
    public Button returnButton;
    void Start()
    {
        Hide();
        againButton.onClick.AddListener(() =>
        {
            //タイマー開始
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        });
        
         returnButton.onClick.AddListener(()=>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenuScene");
        });
    }


}
