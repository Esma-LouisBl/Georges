using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSlider : MonoBehaviour
{
    [SerializeField]
    private PlayerShoot _playerShoot;
    [SerializeField]
    private Slider _gauge;
    // Start is called before the first frame update
    void Start()
    {
        _gauge.maxValue = _playerShoot.charger;
        _gauge.value = _playerShoot.charger;
    }

    // Update is called once per frame
    void Update()
    {
        _gauge.value = _playerShoot.charger;
    }
}
