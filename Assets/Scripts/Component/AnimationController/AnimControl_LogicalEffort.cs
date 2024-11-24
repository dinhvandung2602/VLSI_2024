using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimControl_LogicalEffort : AnimationController
{
    public Image[] lines;
    public GameObject[] graphs;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lines.Length; i++)
        {
            SetGraphOff(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGraphOn(int index)
    {
        lines[index].color = Color.green;
        graphs[index].SetActive(true);
    }

    public void SetGraphOff(int index)
    {
        lines[index].color=Color.white;
        graphs[index].SetActive(false);
    }
}
