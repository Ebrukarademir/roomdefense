using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [SerializeField] private int toplamCan = 10;
    private int gecerliCan;

    [SerializeField] private int toplamZirh = 5;
    private int gecerliZirh;

    [SerializeField] private GameObject playerDamageEffect, playerDeathEffect;

    [HideInInspector]
    public bool zirhVarmi;

    [SerializeField] private SpriteRenderer bodySprite;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        zirhVarmi = true;

        gecerliCan = toplamCan;
        gecerliZirh = toplamZirh;
        UIManager.instance.StartHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);
    }

    public void HasarAlFNC(int hasarMiktari)
    {
        if (gecerliCan <= 0)
            return;

        if (zirhVarmi)
        {
            gecerliZirh -= hasarMiktari;

            UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);

            if (gecerliZirh <= 0)
            {
                zirhVarmi = false;
            }

            return;
        }

        gecerliCan -= hasarMiktari;

        gecerliCan = Mathf.Clamp(gecerliCan, 0, toplamCan);

        UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);

        if (gecerliCan <= 0)
        {
            print("Oyun Bitti");
        }
    }

    public void ZirhiArtirFNC(int artisMiktari)
    {
        gecerliZirh += artisMiktari;

        gecerliZirh = Mathf.Clamp(gecerliZirh, 0, toplamZirh);

        zirhVarmi = true;
        UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);

    }

    public void CaniArtirFNC(int artisMiktari)
    {
        gecerliCan += artisMiktari;
        gecerliCan = Mathf.Clamp(gecerliCan, 0, toplamCan);
        UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);
    }

    public void ToplamCaniArtirFNC()
    {
        toplamCan += 5;
        gecerliCan = toplamCan;

        gecerliCan = Mathf.Clamp(gecerliCan, 0, toplamCan);

        gecerliZirh += 5;
        gecerliZirh = Mathf.Clamp(gecerliZirh, 0, toplamZirh);
        zirhVarmi = true;
        UIManager.instance.UpdateHealthFNC(toplamCan, gecerliCan, toplamZirh, gecerliZirh);
    }

}
