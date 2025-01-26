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

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _mainTheme, _bossTheme;
    void Start()
    {
        _ui.SetActive(false);
        _audioSource.clip = _mainTheme;
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
            _audioSource.clip = _bossTheme;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ui.SetActive(false);
            _audioSource.clip = _mainTheme;
        }
    }
}
