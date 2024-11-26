using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimControl_skew : AnimationController
{
    public Toggle tog_1;
    public Toggle tog_2;
    public Toggle tog_3;

    public GameObject[] content_tog1;
    public GameObject[] content_tog2;
    public GameObject[] content_tog3;

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
            for (int i = 0; i < content_tog1.Length; i++)
            {
                content_tog1[i].SetActive(true);
            }
            for (int i = 0; i < content_tog2.Length; i++)
            {
                content_tog2[i].SetActive(false);
            }
            for (int i = 0; i < content_tog3.Length; i++)
            {
                content_tog3[i].SetActive(false);
            }
        }
        else
        {

        }

    }

    private void OnToggle2Changed(bool isOn)
    {
        if (isOn)
        {
            for (int i = 0; i < content_tog1.Length; i++)
            {
                content_tog1[i].SetActive(false);
            }
            for (int i = 0; i < content_tog2.Length; i++)
            {
                content_tog2[i].SetActive(true);
            }
            for (int i = 0; i < content_tog3.Length; i++)
            {
                content_tog3[i].SetActive(false);
            }
        }
        else
        {

        }

    }

    private void OnToggle3Changed(bool isOn)
    {
        if (isOn)
        {
            for (int i = 0; i < content_tog1.Length; i++)
            {
                content_tog1[i].SetActive(false);
            }
            for (int i = 0; i < content_tog2.Length; i++)
            {
                content_tog2[i].SetActive(false);
            }
            for (int i = 0; i < content_tog3.Length; i++)
            {
                content_tog3[i].SetActive(true);
            }
        }
        else
        {

        }

    }
}
