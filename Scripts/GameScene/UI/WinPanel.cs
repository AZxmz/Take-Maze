using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : PanelController<WinPanel>
{
    public Button yesButton;
    public TMP_InputField inputField;

    void Start()
    {

        yesButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;

            DataManager.Instance.UpdateRankDate(inputField.text, GamePanel.Instance.currentScore, GamePanel.Instance.currentTime);
            SceneManager.LoadScene("MainMenuScene");
        });

        Hide();

        
        
    }

   

}
