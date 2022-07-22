using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    private string keyToSave = "keyHighScore";
    public TextMeshProUGUI uiTMPHighScore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        uiTMPHighScore.text = PlayerPrefs.GetString(keyToSave, "No HighScore");
    }

    public void SavePlayerWin(Player p)
    {
        if (p.namePlayer == "") return;
        PlayerPrefs.SetString(keyToSave, p.namePlayer);
        UpdateText();
    }
}
