using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePoints : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            WinPanel.Instance.Show();
        }
    }
}
