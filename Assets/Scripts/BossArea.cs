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
            _audioSource.volume = 1;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ui.SetActive(false);
            _audioSource.clip = _mainTheme;
            _audioSource.volume = 0.3f;
            _audioSource.Play();
        }
    }
}
