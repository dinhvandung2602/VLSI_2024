using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimController_bubblePushing : AnimationController
{
    public Toggle tog_1;
    public Toggle tog_2;
    public Toggle tog_3;

    // Start is called before the first frame update
    void Start()
    {
        tog_1.onValueChanged.AddListener(OnToggle1Changed);
        OnToggle1Changed(tog_1.isOn);

        tog_2.onValueChanged.AddListener(OnToggle2Changed);
        OnToggle2Changed(tog_2.isOn);

        tog_3.onValueChanged.AddListener(OnToggle3Changed);
        OnToggle3Changed(tog_3.isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggle1Changed(bool isOn)
    {
        if (isOn)
        {
            GetComponentInChildren<Animator>().SetTrigger("exam1");
        }
        else
        {
            
        }

    }

    private void OnToggle2Changed(bool isOn)
    {
        if (isOn)
        {
            GetComponentInChildren<Animator>().SetTrigger("exam2");
        }
        else
        {

        }

    }

    private void OnToggle3Changed(bool isOn)
    {
        if (isOn)
        {
            GetComponentInChildren<Animator>().SetTrigger("exam3");
        }
        else
        {

        }

    }
}
