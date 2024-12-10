using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private Image fillImg;

    [SerializeField] private int maxCan = 100;
    private int gecerliCan;

    private void Start()
    {
        gecerliCan = maxCan;

        fillImg.fillAmount = maxCan;

    }

    public void HasarAlFNC(int hasarMiktari)
    {
        gecerliCan -= hasarMiktari;

        fillImg.DOFillAmount((float)gecerliCan / maxCan, .5f);

        if (gecerliCan <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
