using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MoveBall moveball;
    public static GameManager Instance;
    public StateMachine stateMachine;
    public float timeToSetBallFree = 1;
    public List<Player> players;

    [Header("Menu")]
    public GameObject uiMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        moveball.CanMove(false);
        moveball.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach (var player in players)
        player.ResetPoints();
    }

    private void SetBallFree()
    {
        moveball.CanMove(true);
    }

    public void StartGame()
    {
        moveball.CanMove(true);
    }

    public void EndGame()
    {
        stateMachine.SwitchStates(StateMachine.States.END);
    }

    public void ShowMenu()
    {
        uiMenu.SetActive(true);
        moveball.CanMove(false);
    }
    //
}
