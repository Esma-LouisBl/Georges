using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ProjectilesBehavior ProjectilePrefab;
    public Transform LaunchOffset;

    private float _delay = 0.1f; //delai entre chaque coup

    private int _weapon = 1; // 1 : rifle - 2 : toy

    private bool _canFire = true;

    private int _charger = 500, i = 10;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_canFire == true && _charger > 0)
            {
                _canFire = false;
                if (_weapon == 2)
                {
                    StartCoroutine(RifleDelay());
                }
                else if (_weapon == 1)
                {
                    StartCoroutine(ToyDelay());
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)) // RACCOURCI A SUPPRIMER
        {
            ChangeWeaponToRifle();
        }
    }

    public void ChangeWeaponToRifle()
    {
        _weapon = 2;
    }

    void FireAt()
    {
        _charger -= 5; //vitesse à laquelle le chargeur descend
        Quaternion target = Quaternion.Euler(0, 0, 0);
        transform.localRotation = Quaternion.identity;
        Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation); //cree le projectile au bout de l'arme
    }

    private IEnumerator RifleDelay()
    {
        FireAt();
        yield return new WaitForSeconds(_delay);
        _canFire = true;
    }

    private IEnumerator ToyDelay()
    {
        while (i > 0)
        {
            FireAt();
            i -= 1;
        }
        i = 10;
        yield return new WaitForSeconds(_delay*20);
        _canFire = true;
    }
}
