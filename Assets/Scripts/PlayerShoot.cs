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

    public int charger = 500;
        
    private int i = 10;

    [SerializeField]
    private GameObject _toy, _riffle;

    [SerializeField]
    AudioSource _audioSource;

    void Start()
    {
        _riffle.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_canFire == true && charger > 0)
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
        //if (Input.GetKeyDown(KeyCode.Q)) // RACCOURCI A SUPPRIMER
        //{
        //    ChangeWeaponToRifle();
        //}
    }

    public void ChangeWeaponToRifle()
    {
        _toy.SetActive(false);
        _riffle.SetActive(true);
        _weapon = 2;
    }

    public void FillCharger()
    {
        StartCoroutine(FillingCharger());
        _audioSource.Play();
    }
    public IEnumerator FillingCharger()
    {
        if (charger < 500)
        {
            charger += 25;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void FireAt()
    {
        charger -= 5; //vitesse à laquelle le chargeur descend
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
