using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimController_MachNoiTiepSongSong : AnimationController
{
    Color colorGreen;
    public enum CircuitType
    {
        AND,
        NOR,
        OR,
        NAND
    }

    public CircuitType circuitType;

    public TMP_Text text_g1;
    public TMP_Text text_g2;
    public Toggle toggleG1;
    public Toggle toggleG2;

    public Image gateG1;
    public Image gateG2;
    public Sprite sprite_gateOPEN;
    public Sprite sprite_gateCLOSE;

    public GameObject OnOffIndicator;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#05AF00", out colorGreen);

        if (toggleG1)
        {
            toggleG1.onValueChanged.AddListener(OnToggleG1Changed);
            OnToggleG1Changed(toggleG1.isOn);
        }

        if (toggleG2)
        {
            toggleG2.onValueChanged.AddListener(OnToggleG2Changed);
            OnToggleG2Changed(toggleG2.isOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggleG1Changed(bool isOn)
    {
        if (isOn)
        {
            text_g1.text = "g1 = 1";
            text_g1.color = colorGreen;
        }
        else
        {
            text_g1.text = "g1 = 0";
            text_g1.color = Color.black;
        }

        CalculateOnOff();
    }

    private void OnToggleG2Changed(bool isOn)
    {
        if (isOn)
        {
            text_g2.text = "g2 = 1";
            text_g2.color = colorGreen;
        }
        else
        {
            text_g2.text = "g2 = 0";
            text_g2.color = Color.black;
        }

        CalculateOnOff();
    }

    void CalculateOnOff()
    {
        bool ZeroEqualOpen = true;

        switch (circuitType)
        {
            case CircuitType.AND:
                ZeroEqualOpen = true;

                if(toggleG1.isOn && toggleG2.isOn)
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(true);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(false);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
            case CircuitType.NOR:
                ZeroEqualOpen = false;

                if (!toggleG1.isOn && !toggleG2.isOn)
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(true);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(false);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(true);
                }

                break;
            case CircuitType.OR:
                ZeroEqualOpen = true;

                if (!toggleG1.isOn && !toggleG2.isOn)
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(false);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(true);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
            case CircuitType.NAND:
                ZeroEqualOpen = false;

                if (toggleG1.isOn && toggleG2.isOn)
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(false);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    OnOffIndicator.transform.GetChild(0).gameObject.SetActive(true);
                    OnOffIndicator.transform.GetChild(1).gameObject.SetActive(false);
                }
                break;
        }

        if (ZeroEqualOpen)
        {
            gateG1.sprite = toggleG1.isOn ? sprite_gateCLOSE : sprite_gateOPEN;
            gateG2.sprite = toggleG2.isOn ? sprite_gateCLOSE : sprite_gateOPEN;
        }
        else
        {
            gateG1.sprite = toggleG1.isOn ? sprite_gateOPEN : sprite_gateCLOSE;
            gateG2.sprite = toggleG2.isOn ? sprite_gateOPEN : sprite_gateCLOSE;
        }
    }

}
