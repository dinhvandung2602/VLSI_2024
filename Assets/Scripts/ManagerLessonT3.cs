using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ManagerLessonT3 : MonoBehaviour
{
    public static ManagerLessonT3 instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    
    

    public LessonT2 myLessonT2;
    public TMP_Text Text_MainTitle;
    
    public List<LessonT3> LessonT3List;

    public LessonT3 currentLessonT3 = null;
    public TMP_Text Text_T3Title;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(LessonData.instance.T2Prefab,transform);
        myLessonT2 = GetComponentInChildren<LessonT2>();

        Text_MainTitle.text = LessonData.instance.T2_Index.ToString() + " - " + myLessonT2.LessonTitle;

        foreach(Transform child in myLessonT2.transform)
        {
            LessonT3List.Add(child.GetComponent<LessonT3>());
        }

        SelectLessonT3(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLessonT3(int index)
    {
        currentLessonT3 = LessonT3List[index];
        UpdateInfoT3();
    }

    public void UpdateInfoT3()
    {
        Text_T3Title.text = currentLessonT3.LessonTitle;
    }

    public void BackToT2()
    {
        LessonData.instance.T2Prefab = null;
        SceneManager.LoadScene("Lesson "+LessonData.instance.T1_Index);
    }
}
