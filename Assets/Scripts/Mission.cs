using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMission;
    [SerializeField]
    private Image _frame;

    public bool tutoGeorges = true;
    // Start is called before the first frame update
    void Start()
    {
        _frame.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutoGeorges)
        {
            _textMission.text = "Tirez avec clic gauche sur Georges la chouette pour le purifier !";
        }
        else
        {
            _textMission.text = "";
            _frame.enabled = false;
        }
    }
}
