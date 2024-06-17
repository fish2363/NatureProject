using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpUI : MonoBehaviour
{
    private Slider sliderHp;

    private void Awake()
    {
        sliderHp = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = HpManager.bossCurrentHp;
    }
}
