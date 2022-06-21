using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeRounds : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField inputField;

    public bool numberChanged;
    void Start()
    {
    }

    void Update()
    {
        if (numberChanged)
        {
            ChangeMaxRounds();
            numberChanged = false;
        }
    }

    public void SetNumberChanged()
    {
        numberChanged = true;
    }

    void ChangeMaxRounds()
    {
        PlayerConfigurationManager.Instance.maxAmountOfRounds =  int.Parse(inputField.text);
        //Debug.Log(PlayerConfigurationManager.Instance.maxAmountOfRounds);
    }
}
