using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic; 
using BlGame.GameEntity;

public class XueTiaoBuilding : XueTiaoUI 
{		 
    void Awake()
    {
        hpSprite = transform.FindChild("Control_Hp/Foreground").GetComponent<UISprite>();
        Transform time = transform.FindChild("Time");
        if (time != null)
        {
            TimeSlider = time.GetComponent<UISlider>();
        }
    }

    private UISlider TimeSlider;

    protected override void Update()
    {
        base.Update();
        if (TimeSlider == null)
        {
            return;
        }
        if (xueTiaoOwner.EntityOverplusTotalTime > 0)
        {
            xueTiaoOwner.EntityOverplusRemainTime -= Time.deltaTime;
            if (xueTiaoOwner.EntityOverplusRemainTime < 0)
            {
                xueTiaoOwner.EntityOverplusRemainTime = 0;
                
            }
            TimeSlider.value = xueTiaoOwner.EntityOverplusRemainTime / xueTiaoOwner.EntityOverplusTotalTime;
        }
    }
}
