using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimControl_TinhEffort : AnimationController
{
    public GameObject[] visuals;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < visuals.Length; i++)
        {
            SetVisualOff(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVisualOn(int index)
    {
        visuals[index].gameObject.SetActive(true);
    }

    public void SetVisualOff(int index)
    {
        visuals[index].gameObject.SetActive(false);
    }
}
