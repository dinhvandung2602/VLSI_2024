using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public static bool SoundIsOn = true;

    public Button btn_soundOn;
    public Button btn_soundOff;

    public static Action OnSoundOn;
    public static Action OnSoundOff;

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


    // Start is called before the first frame update
    void Start()
    {
        btn_soundOn.onClick.AddListener(delegate
        {
            SoundOff();
        });
        btn_soundOff.onClick.AddListener(delegate
        {
            SoundOn();
        });

        SetupButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetupButton()
    {
        btn_soundOn.gameObject.SetActive(SoundIsOn);
        btn_soundOff.gameObject.SetActive(!SoundIsOn);
    }

    public void SoundOn()
    {
        SoundIsOn = true;
        OnSoundOn.Invoke();

        btn_soundOn.gameObject.SetActive(true);
        btn_soundOff.gameObject.SetActive(false);
    }

    public void SoundOff()
    {
        SoundIsOn = false;
        OnSoundOff.Invoke();

        btn_soundOn.gameObject.SetActive(false);
        btn_soundOff.gameObject.SetActive(true);
    }
}
