using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] setActive;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private Image black;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < setActive.Length; i++)
        {
            setActive[i].SetActive(false);
        }

        boss.GetComponent<Boss>().enabled = false;
    }

    public void Enable()
    {
        for (int i = 0; i < setActive.Length; i++)
        {
            setActive[i].SetActive(true);
        }
        boss.GetComponent<Boss>().enabled = true;
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        black.DOFade(0, 1);
        yield return new WaitForSecondsRealtime(1f);
    }
}
