using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 設定パネルの管理
/// </summary>
public class SettingPanel : PanelController<SettingPanel>
{
    public Button closeButton;

    public Toggle musicToggle;
    public Toggle soundToggle;

    public Slider musicSlider;
    public Slider soundSlider;

    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {

            Hide();
        });


        musicToggle.onValueChanged.AddListener((isOn) =>
        {
            DataManager.Instance.MusicState(isOn);
        });

        soundToggle.onValueChanged.AddListener((isOn) =>
        {
            DataManager.Instance.SoundState(isOn);
        });

        musicSlider.onValueChanged.AddListener((value) =>
        {
            DataManager.Instance.MusicValue(value);
        });

        soundSlider.onValueChanged.AddListener((value) =>
        {
            DataManager.Instance.SoundValue(value);
        });


        Hide();

    }

    public void UpdateSetting()
    {
        MusicData musicData = DataManager.Instance.musicData;

        musicToggle.isOn = musicData.isOnMusic;
        musicSlider.value = musicData.musicValue;
        soundToggle.isOn = musicData.isOnSound;
        soundSlider.value = musicData.soundValue;
    }

    public override void Show()
    {
        base.Show();
        UpdateSetting();
        Time.timeScale = 0;
    }
    public override void Hide()
    {
        base.Hide();
        Time.timeScale = 1;
    }




}
