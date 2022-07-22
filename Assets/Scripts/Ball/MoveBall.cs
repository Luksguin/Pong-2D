using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [Header("Randomization")]
    public Vector2 randSpeedX = new Vector2(1, 3);
    public Vector2 randSpeedY = new Vector2(1, 3);

    public Vector2 speed = new Vector2 (1, 1);
    public Vector2 startSpeed;
    private Vector2 _startPosition;

    public string keyToCheck;
    public bool _canMove = false;

    private void Awake()
    {
        _startPosition = transform.position;
        startSpeed = speed;
    }

    void Update()
    {
        if (_canMove)
        {
            transform.Translate(speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == keyToCheck)
        {
            PlayerCollision();
        }
        else
        {
            speed.y *= -1;
        }
    }
    public void PlayerCollision()
    {
        speed.x *= -1;
        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if(speed.x < 0)
        {
            rand = -rand;
        }
        speed.x = rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        if(speed.y < 0)
        {
            rand = -rand;
        }
        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
