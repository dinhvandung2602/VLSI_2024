using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class AnimController_CMOSFabrication : AnimationController
{
    public Toggle toggleViewFull;
    public GameObject toggle_labelOn;
    public GameObject toggle_labelOff;

    public Button btn_Replay;

    PlayableDirector m_timeline;

    // Start is called before the first frame update
    void Start()
    {
        if (toggleViewFull)
        {
            toggleViewFull.onValueChanged.AddListener(OnToggleViewFullChanged);
            OnToggleViewFullChanged(toggleViewFull.isOn);
        }

        if (btn_Replay)
        {
            btn_Replay.onClick.AddListener(ReplayTimeline);
        }

        m_timeline = references.GetComponent<PlayableDirector>();
        m_timeline.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggleViewFullChanged(bool isOn)
    {
        if (isOn)
        {
            for(int i = 0; i < references.objLists.Length; i++)
            {
                references.objLists[i].SetActive(true);
            }
            toggle_labelOn.SetActive(true);
            toggle_labelOff.SetActive(false);
        }
        else
        {
            for (int i = 0; i < references.objLists.Length; i++)
            {
                references.objLists[i].SetActive(false);
            }
            toggle_labelOn.SetActive(false);
            toggle_labelOff.SetActive(true);
        }

    }

    public void ReplayTimeline()
    {
        m_timeline.time = 0;
        m_timeline.Play();
    }
}
