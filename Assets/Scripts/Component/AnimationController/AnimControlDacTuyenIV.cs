using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimControlDacTuyenIV : MonoBehaviour
{
    public Slider sld_Vds;
    public TMP_Text Text_sld_Vds;
    public Slider sld_Vgs;
    public TMP_Text Text_sld_Vgs;

    public RectTransform Ids;
    public TMP_Text Text_Ids;

    public GameObject[] lineFrom0to1;

    public GameObject textCutoff;
    public GameObject textLinear;
    public GameObject textSaturation;

    public float VgsMultiplier;
    public bool negativeMultiplier;
    public float input_B;
    public float Vt;
    public float maxIds_value;

    public RectTransform grid;
    float gridHeight;
    float gridWidth;

    float currentIds;

    // Start is called before the first frame update
    void Start()
    {
        gridHeight = grid.rect.height;
        gridWidth = grid.rect.width;


        sld_Vds.onValueChanged.AddListener(delegate
        {
            OnSilderVdsChanged();
        });
        OnSilderVdsChanged();

        sld_Vgs.onValueChanged.AddListener(delegate
        {
            OnSilderVgsChanged();
        });
        OnSilderVgsChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSilderVdsChanged()
    {
        if (!negativeMultiplier)
        {
            Text_sld_Vds.text = (sld_Vds.value).ToString("F2") + "V";
        }
        else
        {
            Text_sld_Vds.text = "-"+(sld_Vds.value).ToString("F2") + "V";
        }
        

        CalculateIds();
    }

    public void OnSilderVgsChanged()
    {
        
        if (!negativeMultiplier)
        {
            Text_sld_Vgs.text = (sld_Vgs.value * VgsMultiplier).ToString("F1") + "V";
        }
        else
        {
            Text_sld_Vgs.text = "-" + (sld_Vgs.value * VgsMultiplier).ToString("F1") + "V";
        }

        for (int i = 0; i < lineFrom0to1.Length; i++)
        {
            if (i == sld_Vgs.value)
            {
                lineFrom0to1[i].SetActive(true);
            }
            else
            {
                lineFrom0to1[i].SetActive(false);
            }
            
        }

        CalculateIds();
    }

    public void CalculateIds()
    {
        float Vgt = sld_Vgs.value * VgsMultiplier - Vt;

        if (sld_Vgs.value * VgsMultiplier < Vt)
        {
            //Cutoff
            currentIds = 0;
            Text_Ids.text = "I<sub>ds</sub> = 0";

            Ids.anchoredPosition = new Vector2(sld_Vds.value * gridWidth, 0);

            textCutoff.SetActive(true);
            textLinear.SetActive(false);
            textSaturation.SetActive(false);
        }
        else
        {
            if (sld_Vds.value < Vgt)
            {
                //Linear
                currentIds = input_B * (Vgt - sld_Vds.value/ 2) * sld_Vds.value;

                if (!negativeMultiplier)
                {
                    Text_Ids.text = "I<sub>ds</sub> = " + currentIds.ToString("F2");
                }
                else
                {
                    Text_Ids.text = "I<sub>ds</sub> = -" + currentIds.ToString("F2");
                }
                

                textCutoff.SetActive(false);
                textLinear.SetActive(true);
                textSaturation.SetActive(false);
            }
            else
            {
                //Saturation
                currentIds = input_B / 2 * Vgt * Vgt;
                if (!negativeMultiplier)
                {
                    Text_Ids.text = "I<sub>ds</sub> = " + currentIds.ToString("F2");
                }
                else
                {
                    Text_Ids.text = "I<sub>ds</sub> = -" + currentIds.ToString("F2");
                }
                    

                textCutoff.SetActive(false);
                textLinear.SetActive(false);
                textSaturation.SetActive(true);
            }

            Ids.anchoredPosition = new Vector2(sld_Vds.value* gridWidth, gridHeight * currentIds / maxIds_value);
            if (currentIds == 0)
            {
                Text_Ids.text = "I<sub>ds</sub> = 0";
            }
        }
    }
}
