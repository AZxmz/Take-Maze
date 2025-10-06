using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランキングデータ管理
/// </summary>
public class RankPanel : PanelController<RankPanel>
{
    public Button closeButton;

    private List<TextMeshProUGUI> sort = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> player = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> score = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> time = new List<TextMeshProUGUI>();

    void Start()
    {
        Hide();
        for (int i = 1; i <= 8; i++)
        {
            sort.Add(this.transform.Find("Sort/Sort" + i).GetComponent<TextMeshProUGUI>());
            player.Add(this.transform.Find("Player/Player" + i).GetComponent<TextMeshProUGUI>());
            score.Add(this.transform.Find("Score/Score" + i).GetComponent<TextMeshProUGUI>());
            time.Add(this.transform.Find("Time/Time" + i).GetComponent<TextMeshProUGUI>());
        }

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });


    }

    public void UpdataRank()
    {
        List<RankData> list = DataManager.Instance.rankDatas.list;

        for (int i = 0; i < list.Count; i++)
        {
            player[i].text = list[i].player;
            score[i].text = list[i].score.ToString();
            int intTime = (int)list[i].time;
            time[i].text = "";

            //秒をそれぞれ時間と分に変換する
            if (intTime / 3600 > 0)
            {
                time[i].text += intTime / 3600 + "h";
            }

            if (intTime % 3600 / 60 > 0 || time[i].text != "")
            {
                time[i].text += intTime % 3600 / 60 + "min";
            }

            time[i].text += intTime % 60 + "s";
        }

    }
    public override void Show()
    {
        base.Show();
        UpdataRank();


    }




}
