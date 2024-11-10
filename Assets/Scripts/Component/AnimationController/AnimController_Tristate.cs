using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimController_Tristate : AnimationController
{
    public Toggle toggle_EN;
    public Toggle toggle_A;
    public Image Image_tristate;
    //Order: EN0 A0 - EN1 A0 - EN0 A1 - EN1 A1
    public Sprite[] sprite_tristate;

    // Start is called before the first frame update
    void Start()
    {
        if (toggle_EN)
        {
            toggle_EN.onValueChanged.AddListener(OnToggleEnChanged);
            OnToggleEnChanged(toggle_EN.isOn);
        }

        if (toggle_A)
        {
            toggle_A.onValueChanged.AddListener(OnToggleAChanged);
            OnToggleAChanged(toggle_A.isOn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnToggleEnChanged(bool isOn)
    {
        CalculateTristate();
    }

    private void OnToggleAChanged(bool isOn)
    {
        CalculateTristate();
    }

    private void CalculateTristate()
    {
        if (!toggle_EN.isOn && !toggle_A.isOn)
        {
            Image_tristate.sprite = sprite_tristate[0];
        }
        if (toggle_EN.isOn && !toggle_A.isOn)
        {
            Image_tristate.sprite = sprite_tristate[1];
        }
        if (!toggle_EN.isOn && toggle_A.isOn)
        {
            Image_tristate.sprite = sprite_tristate[2];
        }
        if (toggle_EN.isOn && toggle_A.isOn)
        {
            Image_tristate.sprite = sprite_tristate[3];
        }
    }

}
