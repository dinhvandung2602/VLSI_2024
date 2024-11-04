using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LessonT2_Button : MonoBehaviour
{
    public TMP_Text Text_NumberingOrder;
    public TMP_Text Text_LessonName;

    public GameObject DataLessonT2;

    // Start is called before the first frame update
    void Start()
    {
        SetButtonInfo();
        SetButtonEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonInfo()
    {
        Text_NumberingOrder.text = (transform.GetSiblingIndex() + 1).ToString();
        Text_LessonName.text = DataLessonT2.GetComponent<LessonT2>().LessonTitle;

    }

    public void SetButtonEvent()
    {
        GetComponent<Button>().onClick.AddListener(LoadSceneT2);
    }

    public void LoadSceneT2()
    {
        LessonData.instance.T2_Index = transform.GetSiblingIndex() + 1;
        LessonData.instance.T2Prefab = DataLessonT2;
        SceneManager.LoadScene("Sub Lesson");
    }
}
