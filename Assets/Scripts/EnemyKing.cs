using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private int _lives = 3;

    private bool _goForward = true;

    [SerializeField]
    private Mission _mission;

    public void Touched()
    {
        if (_lives > 1)
        {
            _lives--;
        }
        else
        {
            Destroy(gameObject);
            _mission.tutoGeorges = false;
        }
    }
}
