using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTaken : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    public GameObject player;

    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;
    private Vector3 knockbackDirection;
    private float knockbackTimer = 0f;
    public Transform spawner;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
            if (playerManager.hp > 1)
            {
                knockbackDirection = (player.transform.position - other.transform.position).normalized;

                knockbackTimer = knockbackDuration;

                playerManager.hp--;
            }
            else
            {
                characterController.enabled = false;
                player.transform.position = spawner.transform.position;
                characterController.enabled = true;

                playerManager.hp = playerManager.maxhp;
            }
        }
    }
}
