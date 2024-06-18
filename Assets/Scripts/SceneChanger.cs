using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public Image fadeIn;
    public void StartScene()
    {
        fadeIn.DOFade(1, 1);
    }
}
