using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LessonT3_Button : MonoBehaviour
{
    public TMP_Text Text_LessonName;
    public GameObject ImageChoosen;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChooseEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        Text_LessonName.text = name;
    }

    public void ChooseEvent()
    {
        ManagerLessonT3.instance.SelectLessonT3(transform.GetSiblingIndex());
    }

    public void BeingChoosen()
    {
        ImageChoosen.SetActive(true);

    }

    public void UnChoosen()
    {
        ImageChoosen.SetActive(false);
    }
}
