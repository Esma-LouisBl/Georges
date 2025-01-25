using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ProjectilesBehavior ProjectilePrefab;
    public Transform LaunchOffset;

    [SerializeField]
    private float _delay = 0.1f; //délai entre chaque coup

    private bool _canFire = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_canFire == true)
            {
                _canFire = false;
                Debug.Log("Boum");
                StartCoroutine(SprayDelay());
            }
        }
    }

    void FireAt()
    {
        Quaternion target = Quaternion.Euler(0, 0, 0);
        transform.localRotation = Quaternion.identity;
        Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation);
        Debug.Log("Boum");
    }

    private IEnumerator SprayDelay()
    {
        FireAt();
        yield return new WaitForSeconds(_delay);
        _canFire = true;
    }
}
