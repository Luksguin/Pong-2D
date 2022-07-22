using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public string namePlayer;
    public Player player;
    public TextMeshProUGUI nameUGUI;
    public TMP_InputField nameInputField;
    public GameObject buttonsName;

    public void OnClick()
    {
        buttonsName.SetActive(true);
    }

    public void ChangeName()
    {
        namePlayer = nameInputField.text;
        nameUGUI.text = nameInputField.text;
        player.SetName(namePlayer);
    }
}
