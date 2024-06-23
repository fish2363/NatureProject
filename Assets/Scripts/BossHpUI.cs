using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpUI : MonoBehaviour
{
    [SerializeField]
    private Slider bossSliderHp;
    [SerializeField]
    private Slider playerSliderHP;    
    [SerializeField]
    private Slider skillSliderCool;
    [SerializeField]
    private Slider hunterBoss;


    // Update is called once per frame
    void Update()
    {
        skillSliderCool.value = Skill.CoolTime;
        bossSliderHp.value = HpManager.bossCurrentHp;
        playerSliderHP.value = HpManager.instance.playerHp;
        hunterBoss.value = Hunter.myHp;
    }
}
