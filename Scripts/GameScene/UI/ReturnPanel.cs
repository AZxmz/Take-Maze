using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnPanel : PanelController<ReturnPanel>
{
    public Button yesButton;
    public Button noButton;
    public Button closeButton;
    void Start()
    {
        Hide();
        yesButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenuScene");
        });

        noButton.onClick.AddListener(() =>
        {
            Hide();

        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    public override void Hide()
    {
        base.Hide();
        Time.timeScale = 1;
    }

    public override void Show()
    {
        base.Show();
        //タイマー一時停止
        Time.timeScale = 0;
    }

}
