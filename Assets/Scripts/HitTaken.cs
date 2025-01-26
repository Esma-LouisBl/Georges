using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTaken : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    [SerializeField]
    private EnemyKing _enemyKing;

    public GameObject player;

    [SerializeField]
    private Image _hpImage;
    [SerializeField]
    private Sprite _hpMax, _hp2, _hp1, _dead;

    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;
    private Vector3 knockbackDirection;
    private float knockbackTimer = 0f;

    private bool _invincible = false;
    [SerializeField]
    private int _invincibilityTime = 3;

    public Transform spawner;

    private CharacterController characterController;

    [SerializeField]
    private AudioSource _audioSource;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _hpImage.sprite = _hpMax;
    }

    void Update()
    {
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;
            characterController.Move(knockbackDirection * knockbackForce * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!_invincible)
            {   
                _audioSource.Play();

                if (playerManager.hp > 1)
                {
                    knockbackDirection = (player.transform.position - other.transform.position).normalized;

                    knockbackTimer = knockbackDuration;

                    playerManager.hp--;

                    if (playerManager.hp == 2)
                    {
                        _hpImage.sprite = _hp2;
                    }
                    else if (playerManager.hp == 1)
                    {
                        _hpImage.sprite = _hp1;
                    }
                }
                else
                {
                    characterController.enabled = false;
                    player.transform.position = spawner.transform.position;
                    characterController.enabled = true;

                    playerManager.hp = playerManager.maxhp;

                    _hpImage.sprite = _hpMax;

                    _enemyKing.lives = 100;
                }

                StartCoroutine(Invincibility());
            }
        }
        else if (other.CompareTag("Wave"))
        {
            _audioSource.Play();
            if (playerManager.hp > 1)
            {
                knockbackDirection = ((player.transform.position - other.transform.position)*2).normalized;

                knockbackTimer = knockbackDuration;

                playerManager.hp -= 1;

                if (playerManager.hp == 2)
                {
                    _hpImage.sprite = _hp2;
                }
                else if (playerManager.hp == 1)
                {
                    _hpImage.sprite = _hp1;
                }
            }
            else
            {
                characterController.enabled = false;
                player.transform.position = spawner.transform.position;
                characterController.enabled = true;

                playerManager.hp = playerManager.maxhp;

                _hpImage.sprite = _hpMax;

                _enemyKing.lives = 100;
            }
            StartCoroutine(Invincibility());
        }
        else if (other.CompareTag("Respawn"))
        {
            spawner = other.transform;
        }
        else if (other.CompareTag("KillZone"))
        {
            characterController.enabled = false;
            player.transform.position = spawner.transform.position;
            characterController.enabled = true;

            playerManager.hp = playerManager.maxhp;

            _hpImage.sprite = _hpMax;

            _enemyKing.lives = 100;
        }
    }

    IEnumerator Invincibility()
    {
        _invincible = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _invincible = false;
    }

}
