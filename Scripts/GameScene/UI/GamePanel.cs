using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : PanelController<GamePanel>
{
    public Button settingButton;
    public Button returnButton;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    public Image HPimage;

    public float currentTime;
    public int currentScore;
    void Start()
    {
        settingButton.onClick.AddListener(() =>
        {
            SettingPanel.Instance.Show();
        });

        returnButton.onClick.AddListener(() =>
        {
            ReturnPanel.Instance.Show();
        });

        


    }


    void Update()
    {

        UpdateTime();
    }


    public void UpdateHp(int currentHp, int maxHp)
    {
        HPimage.fillAmount = (float)currentHp / maxHp;
    }

    public void UpdateScore(int scoreNumber)
    {
        currentScore += scoreNumber;
        score.text = currentScore.ToString();
    }

    private void UpdateTime()
    {
        currentTime += Time.deltaTime;
        int intCurrentTime = (int)currentTime;
        time.text = "";
        if (intCurrentTime / 3600 > 0)
        {
            time.text += intCurrentTime / 3600 + "h";
        }
        if (intCurrentTime % 3600 / 60 > 0 || time.text != "")
        {
            time.text += intCurrentTime % 3600 / 60 + "min";
        }
        
        time.text += intCurrentTime % 60 + "s";
        }
}
