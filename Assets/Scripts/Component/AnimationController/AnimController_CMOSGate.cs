using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimController_CMOSGate : AnimationController
{
    Color colorGreen;
    Color colorRed;

    [Header("Cong CMOS transitor")]
    public Toggle toggle_gate;
    public TMP_Text toggle_gate_Text;
    public Image Image_nMos;
    public Image Image_pMos;
    public Sprite sprite_gateON;
    public Sprite sprite_gateOFF; 
    public GameObject OnOffIndicator_nMOS;
    public GameObject OnOffIndicator_pMOS;

    [Header("CMOS Inverter")]
    public Toggle toggle_inverter_A;
    public TMP_Text inverter_A_Text;
    public TMP_Text inverter_Q_Text;
    public Image Image_Inverter;
    //Order: A0 - A1
    public Sprite[] sprite_inverter;
    
    [Header("NAND")]
    public Toggle toggle_NAND_A;
    public Toggle toggle_NAND_B;
    public TMP_Text NAND_A_Text;
    public TMP_Text NAND_B_Text;
    public TMP_Text NAND_Y_Text;
    public Image Image_NAND;
    //Order: A0 B0 - A1 B0 - A0 B1 - A1 B1
    public Sprite[] sprite_NAND;

    [Header("NOR")]
    //Giong NAND, chi khac Y
    public TMP_Text NOR_Y_Text;

    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString("#05AF00", out colorGreen);
        ColorUtility.TryParseHtmlString("#C7091B", out colorRed);

        if (toggle_gate)
        {
            toggle_gate.onValueChanged.AddListener(OnToggleGateChanged);
            OnToggleGateChanged(toggle_gate.isOn);
        }

        if (toggle_inverter_A)
        {
            toggle_inverter_A.onValueChanged.AddListener(OnToggleInverterAChanged);
            OnToggleInverterAChanged(toggle_inverter_A.isOn);
        }

        if (toggle_NAND_A)
        {
            toggle_NAND_A.onValueChanged.AddListener(OnToggleNAND_A_Changed);
            OnToggleNAND_A_Changed(toggle_NAND_A.isOn);
        }

        if (toggle_NAND_B)
        {
            toggle_NAND_B.onValueChanged.AddListener(OnToggleNAND_B_Changed);
            OnToggleNAND_B_Changed(toggle_NAND_B.isOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggleGateChanged(bool isOn)
    {
        if (isOn)
        {
            toggle_gate_Text.text = "g = 1";
            Image_nMos.sprite = sprite_gateON;
            Image_pMos.sprite = sprite_gateOFF;

            OnOffIndicator_nMOS.transform.GetChild(0).gameObject.SetActive(true);
            OnOffIndicator_nMOS.transform.GetChild(1).gameObject.SetActive(false);

            OnOffIndicator_pMOS.transform.GetChild(0).gameObject.SetActive(false);
            OnOffIndicator_pMOS.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            toggle_gate_Text.text = "g = 0";
            Image_nMos.sprite = sprite_gateOFF;
            Image_pMos.sprite = sprite_gateON;

            OnOffIndicator_nMOS.transform.GetChild(0).gameObject.SetActive(false);
            OnOffIndicator_nMOS.transform.GetChild(1).gameObject.SetActive(true);

            OnOffIndicator_pMOS.transform.GetChild(0).gameObject.SetActive(true);
            OnOffIndicator_pMOS.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void OnToggleInverterAChanged(bool isOn)
    {
        if (isOn)
        {
            inverter_A_Text.text = "A = 1";
            inverter_A_Text.color = colorGreen;
            inverter_Q_Text.text = "Q = 0";
            inverter_Q_Text.color = Color.black;
            Image_Inverter.sprite = sprite_inverter[1];
        }
        else
        {
            inverter_A_Text.text = "A = 0";
            inverter_A_Text.color = Color.black;
            inverter_Q_Text.text = "Q = 1";
            inverter_Q_Text.color = colorGreen;
            Image_Inverter.sprite = sprite_inverter[0];

        }
    }

    private void OnToggleNAND_A_Changed(bool isOn)
    {
        if (isOn)
        {
            NAND_A_Text.text = "A = 1";
            NAND_A_Text.color = colorGreen;
        }
        else
        {
            NAND_A_Text.text = "A = 0";
            NAND_A_Text.color = Color.black;
        }

        CalculateNAND();
        CalculateNOR();
    }

    private void OnToggleNAND_B_Changed(bool isOn)
    {
        if (isOn)
        {
            NAND_B_Text.text = "B = 1";
            NAND_B_Text.color = colorGreen;
        }
        else
        {
            NAND_B_Text.text = "B = 0";
            NAND_B_Text.color = Color.black;
        }

        CalculateNAND();
        CalculateNOR();
    }

    void CalculateNAND()
    {
        if (NAND_Y_Text)
        {
            if (!toggle_NAND_A.isOn && !toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[0];
                NAND_Y_Text.text = "Y = 1";
                NAND_Y_Text.color = colorGreen;
            }
            if (toggle_NAND_A.isOn && !toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[1];
                NAND_Y_Text.text = "Y = 1";
                NAND_Y_Text.color = colorGreen;
            }
            if (!toggle_NAND_A.isOn && toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[2];
                NAND_Y_Text.text = "Y = 1";
                NAND_Y_Text.color = colorGreen;
            }
            if (toggle_NAND_A.isOn && toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[3];
                NAND_Y_Text.text = "Y = 0";
                NAND_Y_Text.color = Color.black;
            }
        }
        
    }

    void CalculateNOR()
    {
        if (NOR_Y_Text)
        {
            if (!toggle_NAND_A.isOn && !toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[0];
                NOR_Y_Text.text = "Y = 1";
                NOR_Y_Text.color = colorGreen;
            }
            if (toggle_NAND_A.isOn && !toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[1];
                NOR_Y_Text.text = "Y = 0";
                NOR_Y_Text.color = Color.black;
            }
            if (!toggle_NAND_A.isOn && toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[2];
                NOR_Y_Text.text = "Y = 0";
                NOR_Y_Text.color = Color.black;
            }
            if (toggle_NAND_A.isOn && toggle_NAND_B.isOn)
            {
                Image_NAND.sprite = sprite_NAND[3];
                NOR_Y_Text.text = "Y = 0";
                NOR_Y_Text.color = Color.black;
            }
        }
    }
}
