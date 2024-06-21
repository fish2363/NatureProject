using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShakingManager : MonoBehaviour
{
    public static CameraShakingManager instance;

    [SerializeField]
    private Camera shakeCamera;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator ShakeCamera(float duration, float strength, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        shakeCamera.DOShakePosition(duration, strength);
    }
}
