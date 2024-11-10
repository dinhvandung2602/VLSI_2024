using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimControlMux : AnimationController
{
    Color colorGreen;
    Color colorRed;
    Color colorBlue;

    [Header("MUX")]
    public Toggle toggle_S;
    public Toggle toggle_D0;
    public Toggle toggle_D1;
    public TMP_Text text_S_1;
    public TMP_Text text_S_2;
    public TMP_Text text_S_invert;
    public TMP_Text text_D0;
    public TMP_Text text_D1;
    public TMP_Text text_Y;

    public GameObject S1;
    public GameObject S0;
    public GameObject D0;
    public GameObject D1;
    public GameObject D0_way;
    public GameObject D1_way;

    [Header("MUX 41")]
    public Toggle toggle_S0;
    public Toggle toggle_S1;
    public TMP_Text text_S0;
    public TMP_Text text_S1;
    public Image Image_MUX_41;
    //Order: S0 S0 - S1 S0 - S0 S1 - S1 S1
    public Sprite[] sprite_Mux41;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#05AF00", out colorGreen);
        ColorUtility.TryParseHtmlString("#C7091B", out colorRed);
        ColorUtility.TryParseHtmlString("#00ADE9", out colorBlue);

        if (toggle_S)
        {
            toggle_S.onValueChanged.AddListener(OnToggleSChanged);
            OnToggleSChanged(toggle_S.isOn);
        }

        if (toggle_D0)
        {
            toggle_D0.onValueChanged.AddListener(OnToggleD0Changed);
            OnToggleD0Changed(toggle_D0.isOn);
        }

        if (toggle_D1)
        {
            toggle_D1.onValueChanged.AddListener(OnToggleD1Changed);
            OnToggleD1Changed(toggle_D1.isOn);
        }

        if (toggle_S0)
        {
            toggle_S0.onValueChanged.AddListener(OnToggleS0Changed);
            OnToggleS0Changed(toggle_S0.isOn);
        }

        if (toggle_S1)
        {
            toggle_S1.onValueChanged.AddListener(OnToggleS1Changed);
            OnToggleS1Changed(toggle_S1.isOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggleSChanged(bool isOn)
    {
        if(isOn)
        {
            S0.SetActive(false);
            S1.SetActive(true);

            text_S_1.text = "S = 1";
            text_S_2.text = "S = 1";
            text_S_1.color = colorGreen;
            text_S_2.color = colorGreen;

            text_S_invert.text = "S = 0";
            text_S_invert.color = Color.black;

            text_S_invert.GetComponentInChildren<Image>().color = Color.black;
        }
        else
        {
            S0.SetActive(true);
            S1.SetActive(false);

            text_S_1.text = "S = 0";
            text_S_2.text = "S = 0";
            text_S_1.color = Color.black;
            text_S_2.color = Color.black;

            text_S_invert.text = "S = 1";
            text_S_invert.color = colorGreen;

            text_S_invert.GetComponentInChildren<Image>().color = colorGreen;
        }

        CalculateMux();
    }

    private void OnToggleD0Changed(bool isOn)
    {
        if (isOn)
        {
            D0.SetActive(true);
            text_D0.text = "D0 = 1";
            text_D0.color = colorGreen;
        }
        else
        {
            D0.SetActive(false);
            text_D0.text = "D0 = 0";
            text_D0.color = Color.black;
        }

        CalculateMux();
    }

    private void OnToggleD1Changed(bool isOn)
    {
        if (isOn)
        {
            D1.SetActive(true);
            text_D1.text = "D1 = 1";
            text_D1.color = colorGreen;
        }
        else
        {
            D1.SetActive(false);
            text_D1.text = "D1 = 0";
            text_D1.color = Color.black;
        }

        CalculateMux();
    }

    void CalculateMux()
    {
        if (toggle_S.isOn)
        {
            if (toggle_D1.isOn)
            {
                D1_way.SetActive(true);
                text_Y.text = "Y = 1";
                text_Y.color = colorGreen;
            }
            else
            {
                D1_way.SetActive(false);
                text_Y.text = "Y = 0";
                text_Y.color = Color.black;
            }

            D0_way.SetActive(false);
        }
        else
        {
            if (toggle_D0.isOn)
            {
                D0_way.SetActive(true);
                text_Y.text = "Y = 1";
                text_Y.color = colorGreen;
            }
            else
            {
                D0_way.SetActive(false);
                text_Y.text = "Y = 0";
                text_Y.color = Color.black;
            }

            D1_way.SetActive(false);
        }
    }




    private void OnToggleS0Changed(bool isOn)
    {
        if (isOn)
        {
            text_S0.text = "S0 = 1";
            text_S0.color = colorBlue;
        }
        else
        {
            text_S0.text = "S0 = 0";
            text_S0.color = Color.black;
        }

        CalculateMux41();

    }

    private void OnToggleS1Changed(bool isOn)
    {
        if (isOn)
        {
            text_S1.text = "S1 = 1";
            text_S1.color = colorBlue;
        }
        else
        {
            text_S1.text = "S1 = 0";
            text_S1.color = Color.black;
        }

        CalculateMux41();
    }

    void CalculateMux41()
    {
        if (!toggle_S0.isOn && !toggle_S1.isOn)
        {
            Image_MUX_41.sprite = sprite_Mux41[0];
        }
        if (toggle_S0.isOn && !toggle_S1.isOn)
        {
            Image_MUX_41.sprite = sprite_Mux41[1];
        }
        if (!toggle_S0.isOn && toggle_S1.isOn)
        {
            Image_MUX_41.sprite = sprite_Mux41[2];
        }
        if (toggle_S0.isOn && toggle_S1.isOn)
        {
            Image_MUX_41.sprite = sprite_Mux41[3];
        }

    }

}
