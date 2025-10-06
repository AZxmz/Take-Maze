using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// メインメニューボタンを管理する
/// </summary>
public class MainMenuPanel : PanelController<MainMenuPanel>
{
    public Button startButton;
    public Button settingButton;
    public Button QuitButton;
    public Button rankButton;
    void Start()
    {
        startButton.onClick.AddListener(() =>
        {

            SceneManager.LoadScene("GameScene");

        });

        settingButton.onClick.AddListener(() =>
        {
            SettingPanel.Instance.Show();
        });

        QuitButton.onClick.AddListener(() =>
        {

            Application.Quit();
        });

        rankButton.onClick.AddListener(() =>
        {
            RankPanel.Instance.Show();
        });
    }


}
