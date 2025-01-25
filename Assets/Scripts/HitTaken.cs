using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTaken : MonoBehaviour
{
    public GameObject player;

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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            characterController.enabled = false;
            player.transform.position = spawner.transform.position;
            characterController.enabled = true;
        }
    }
}
