using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public string namePlayer;
    public int maxPoints;
    public float speed;
    public Image uiPlayer;

    [Header("Keys Setup")]
    public KeyCode KeyCodeUp;
    public KeyCode KeyCodeDown;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTexMashPoints;

    public void SetName(string s)
    {
        namePlayer = s;
    }

    private void Awake()
    {
        ResetPoints();
    }

    public void ResetPoints()
    {
        currentPoints = 0;
        UpdateUI();
    }

    public Rigidbody2D myRigidbody2D;

    void Update()
    {
        if (Input.GetKey(KeyCodeUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        }
        else if (Input.GetKey(KeyCodeDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
        CheckPoints();
        UpdateUI();
    }

    public void UpdateUI()
    {
        uiTexMashPoints.text = currentPoints.ToString();
    }

    public void CheckPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            currentPoints = -1;
            HighScoreManager.Instance.SavePlayerWin(this);
        }
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
}
