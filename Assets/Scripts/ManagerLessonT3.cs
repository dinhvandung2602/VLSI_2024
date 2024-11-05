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
    public GameObject ButtonT3Prefab;
    public Transform ButtonT3Group;
    public List<LessonT3_Button> LessonT3ButtonList;

    public Button ButtonPrev;
    public Button ButtonNext;

    public LessonT3 currentLessonT3 = null;
    public int currentT3Index = 0;
    public TMP_Text Text_T3Title;
    public Transform TextInfoGroup;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(LessonData.instance.T2Prefab,transform);
        myLessonT2 = GetComponentInChildren<LessonT2>();

        Text_MainTitle.text = LessonData.instance.T2_Index.ToString() + " - " + myLessonT2.LessonTitle;

        ButtonNext.onClick.AddListener(ChooseNext);
        ButtonPrev.onClick.AddListener(ChoosePrev);

        foreach (Transform child in myLessonT2.transform)
        {
            LessonT3List.Add(child.GetComponent<LessonT3>());

            GameObject bT3 = Instantiate(ButtonT3Prefab, ButtonT3Group);
            LessonT3ButtonList.Add(bT3.GetComponent<LessonT3_Button>());
            bT3.GetComponent<LessonT3_Button>().SetName(child.GetComponent<LessonT3>().LessonTitle);
        }

        SelectLessonT3(0);
        ButtonT3Group.GetComponentInParent<ScrollRect>().horizontalNormalizedPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ButtonNext.onClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ButtonPrev.onClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            BackToT2();
        }
    }

    public void SelectLessonT3(int index)
    {
        currentLessonT3 = LessonT3List[index];
        currentT3Index = index;
        LessonT3ButtonList[index].BeingChoosen();
        LessonT3ButtonList[index].Text_LessonName.text= currentLessonT3.LessonTitle;

        FocusOnItem(LessonT3ButtonList[index].GetComponent<RectTransform>());

        for (int i = 0; i < LessonT3ButtonList.Count; i++)
        {
            if (i != index)
            {
                LessonT3ButtonList[i].UnChoosen();
            }
        }
        UpdateInfoT3();
        UpdateButtonNextPrev();
    }

    public void UpdateInfoT3()
    {
        Text_T3Title.text = currentLessonT3.LessonTitle;

        foreach (Transform child in TextInfoGroup)
        {
            GameObject.Destroy(child.gameObject);
        }
        Instantiate(currentLessonT3.TextInfo, TextInfoGroup);
        LayoutRebuilder.ForceRebuildLayoutImmediate(TextInfoGroup.GetComponent<RectTransform>());
    }

    public void ChooseNext()
    {
        if (ButtonNext.interactable)
        {
            SelectLessonT3(currentT3Index + 1);
        }
    }

    public void ChoosePrev()
    {
        if (ButtonPrev.interactable)
        {
            SelectLessonT3(currentT3Index - 1);
        }
    }

    public void UpdateButtonNextPrev()
    {
        if (currentT3Index <= 0)
        {
            ButtonPrev.interactable = false;
        }
        else
        {
            ButtonPrev.interactable = true;
        }

        if(currentT3Index >= (LessonT3List.Count - 1))
        {
            ButtonNext.interactable = false;
        }
        else
        {
            ButtonNext.interactable = true;
        }
    }


    public void FocusOnItem(RectTransform selectedItem)
    {
        float contentWidth = ButtonT3Group.GetComponent<RectTransform>().rect.width;

        float normalizedPositionX = Mathf.Clamp01((selectedItem.GetComponent<RectTransform>().anchoredPosition.x - selectedItem.GetComponent<RectTransform>().rect.width / 2) / (contentWidth - selectedItem.GetComponent<RectTransform>().rect.width));

        ButtonT3Group.GetComponentInParent<ScrollRect>().horizontalNormalizedPosition = normalizedPositionX;

    }

    public void BackToT2()
    {
        LessonData.instance.T2Prefab = null;
        SceneManager.LoadScene("Lesson "+LessonData.instance.T1_Index);
    }
}
