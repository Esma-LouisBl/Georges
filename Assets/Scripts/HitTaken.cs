using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTaken : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

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
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _hpImage.sprite = _hpMax;
    }

    // Update is called once per frame
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
                }

                StartCoroutine(Invincibility());
            }
        }
        else if (other.CompareTag("Respawn"))
        {
            spawner = other.transform;
        }
    }

    IEnumerator Invincibility()
    {
        _invincible = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _invincible = false;
    }

}
