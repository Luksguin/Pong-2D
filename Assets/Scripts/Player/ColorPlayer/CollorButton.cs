using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollorButton : MonoBehaviour
{
    public Color color;
    public Player player;

    [Header("References")]
    public Image uiImage;

    void Start()
    {
        uiImage.color = color;
    }

    public void OnClick()
    {
        player.ChangeColor(color);
    }
}
