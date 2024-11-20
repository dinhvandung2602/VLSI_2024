using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class AnimControllerStickPractice : AnimationController
{
    public PlayableDirector playableDirector; // Reference to the PlayableDirector
    public Slider timelineSlider;

    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        timelineSlider.onValueChanged.AddListener(OnSliderValueChanged);

        if (playableDirector != null && timelineSlider != null)
        {
            // Set Slider's Min and Max
            timelineSlider.minValue = 0;
            timelineSlider.maxValue = (float)playableDirector.duration;

            // Update the slider as the timeline progresses
            playableDirector.played += OnTimelinePlay;
            playableDirector.stopped += OnTimelineStop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Sync the slider with the Timeline if not dragging
        if (!isDragging && playableDirector != null && timelineSlider != null)
        {
            timelineSlider.value = (float)playableDirector.time;
        }
        print(isDragging);
    }

    public void OnSliderValueChanged(float value)
    {
        if (playableDirector != null && isDragging)
        {
            // Set the Timeline time to match the slider
            playableDirector.time = value;
        }
    }

    public void OnSliderDragStart()
    {
        isDragging = true;
    }

    public void OnSliderDragEnd()
    {
        isDragging = false;
        if (playableDirector != null)
        {
            playableDirector.Play();
        }
    }

    private void OnTimelinePlay(PlayableDirector director)
    {
        if (timelineSlider != null)
        {
            timelineSlider.maxValue = (float)playableDirector.duration;
        }
    }

    private void OnTimelineStop(PlayableDirector director)
    {
        timelineSlider.value = 0;
    }
}
