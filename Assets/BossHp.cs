using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    [SerializeField]
    private Slider bossSliderHp;
    [SerializeField]
    private Slider playerSliderHp;

    void Update()
    {
        bossSliderHp.value = PageTwoBoss.myHp;
        playerSliderHp.value = HpManagerSecond.instance.playerHp;
    }
}
