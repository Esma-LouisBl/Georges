using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private PlayerShoot _playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        _weapon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _weapon)
        {
            Destroy(_weapon);
            _playerShoot.ChangeWeaponToRifle();
        }
    }
}
