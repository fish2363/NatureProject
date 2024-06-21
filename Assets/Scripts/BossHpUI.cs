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


    // Update is called once per frame
    void Update()
    {
        bossSliderHp.value = HpManager.bossCurrentHp;
        playerSliderHP.value = HpManager.instance.playerHp;
    }
}
