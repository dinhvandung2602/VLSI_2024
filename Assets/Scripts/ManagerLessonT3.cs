using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

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

    public GameObject View3D;
    public GameObject ViewImage;
    public GameObject ViewVideo;
    public Transform UIController3D;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(LessonData.instance.T2Prefab,transform);
        myLessonT2 = GetComponentInChildren<LessonT2>();

        Text_MainTitle.text = LessonData.instance.T2_Index.ToString() + " - " + myLessonT2.LessonTitle;
        GetComponent<AudioSource>().clip = myLessonT2.BriefVoiceT2;

        ButtonNext.onClick.AddListener(ChooseNext);
        ButtonPrev.onClick.AddListener(ChoosePrev);

        foreach (Transform child in myLessonT2.transform)
        {
            LessonT3List.Add(child.GetComponent<LessonT3>());

            GameObject bT3 = Instantiate(ButtonT3Prefab, ButtonT3Group);
            LessonT3ButtonList.Add(bT3.GetComponent<LessonT3_Button>());
            bT3.GetComponent<LessonT3_Button>().SetName(child.GetComponent<LessonT3>().LessonTitle);
        }

        StartCoroutine(delaySelectFirstButton());
        ButtonT3Group.GetComponentInParent<ScrollRect>().horizontalNormalizedPosition = 0;

        if (SoundManager.SoundIsOn)
        {
            PLayVoiceBriefT2();
        }
    }

    void OnEnable()
    {
        SoundManager.OnSoundOn += PLayVoiceBriefT2;
        SoundManager.OnSoundOff += StopVoiceBriefT2;
    }

    void OnDisable()
    {
        SoundManager.OnSoundOn -= PLayVoiceBriefT2;
        SoundManager.OnSoundOff -= StopVoiceBriefT2;
    }

    IEnumerator delaySelectFirstButton()
    {
        yield return new WaitForSeconds(0.1f);
        SelectLessonT3(0);
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

    public void PLayVoiceBriefT2()
    {
        GetComponent<AudioSource>().Play();
    }

    public void StopVoiceBriefT2()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void SelectLessonT3(int index)
    {
        currentLessonT3 = LessonT3List[index];
        currentT3Index = index;
        LessonT3ButtonList[index].BeingChoosen();
        LessonT3ButtonList[index].Text_LessonName.text= currentLessonT3.LessonTitle;

        FocusOnItem(LessonT3ButtonList[index].GetComponent<RectTransform>());


        LessonT3List[index].gameObject.SetActive(true);

        for (int i = 0; i < LessonT3ButtonList.Count; i++)
        {
            if (i != index)
            {
                LessonT3List[i].gameObject.SetActive(false);
                LessonT3ButtonList[i].UnChoosen();
            }
        }

        //reset scroll Text info
        TextInfoGroup.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 1;

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
        if(currentLessonT3.TextInfo) Instantiate(currentLessonT3.TextInfo, TextInfoGroup);


        //Set Content Info
        switch (currentLessonT3.contentType)
        {
            case LessonT3.ContentType.Interactive:
                View3D.SetActive(true);
                ViewImage.SetActive(false);
                ViewVideo.SetActive(false);

                View3D.GetComponentInChildren<RawImage>().enabled = true;

                View3D.GetComponent<CameraRotate>().ResetAngle();

                foreach (Transform child in UIController3D)
                {
                    GameObject.Destroy(child.gameObject);
                }

                //Set UI controller 3D
                if (currentLessonT3.UIController3D)
                {
                    GameObject uiController = Instantiate(currentLessonT3.UIController3D, UIController3D);

                    //Link to model3D references
                    if (uiController.GetComponent<AnimationController>())
                    {
                        uiController.GetComponent<AnimationController>().references = LessonT3List[currentT3Index].GetComponentInChildren<ModelPrefabRef>();
                    }
                }
                
                break;
            case LessonT3.ContentType.Image:
                View3D.SetActive(false);
                ViewImage.SetActive(true);
                ViewVideo.SetActive(false);

                View3D.GetComponentInChildren<RawImage>().enabled = false;

                ViewImage.GetComponent<Image>().sprite = currentLessonT3.Picture;
                break;
            case LessonT3.ContentType.Video:
                View3D.SetActive(false);
                ViewImage.SetActive(false);
                ViewVideo.SetActive(true);

                View3D.GetComponentInChildren<RawImage>().enabled = false;

                ViewVideo.GetComponentInChildren<MyVideoPlayer>().ResetVideoPlayer();
                ViewVideo.GetComponentInChildren<VideoPlayer>().clip = currentLessonT3.Video;
                break;
        }
        

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
