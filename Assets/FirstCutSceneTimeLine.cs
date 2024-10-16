using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using DG.Tweening;

public class FirstCutSceneTimeLine : MonoBehaviour
{
    public GameObject miniDeer;
    public GameObject startButton;
    // Start is called before the first frame update
    


    public void SizeUp()
    {
        miniDeer.GetComponent<SpriteRenderer>().sortingOrder = 10;

        Sequence seq = DOTween.Sequence();

        seq.Prepend(miniDeer.transform.DOScale(new Vector3(80, 80, 80), 0.6f));
        StartCoroutine(CameraShakingManager.instance.ShakeCamera(1,3,0.5f));
    }



    public void HideOnButton()
    {
        //startButton.GetComponent<Im>().DOFade(1,1);
    }
}
