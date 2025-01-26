using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
    [SerializeField]
    private GameObject _ui;
    [SerializeField]
    private EnemyKing _enemyKing;
    [SerializeField]
    private BoxCollider _area;
    void Start()
    {
        _ui.SetActive(false);
    }

    void Update()
    {
        if (_enemyKing.lives < 1)
        {
            _ui.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ui.SetActive(false);
        }
    }
}
