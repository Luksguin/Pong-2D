using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public Player player;

    public string tagToLook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == tagToLook)
        {
            CountPoint();
        }
    }

    public void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoints();
    }
}
