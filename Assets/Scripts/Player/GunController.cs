using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private PlayerBullet mermiPrefab;
    [SerializeField] private Transform mermiCikisNoktasi;

    [Range(0.01f, 2f)]
    [SerializeField] private float mermiAtisSuresi = .25f;
    private float mermiAtisSayac;

    [SerializeField] private GameObject atesEtmeEfekti;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > mermiAtisSayac)
        {
            // Instantiate(mermiPrefab, mermiCikisNoktasi.position, mermiCikisNoktasi.rotation);

            mermiPrefab = ObjectPool.instance.MermiCikarFNC();

            if (mermiPrefab)
            {
                mermiPrefab.transform.position = mermiCikisNoktasi.position;
                mermiPrefab.transform.rotation = mermiCikisNoktasi.rotation;
                mermiPrefab.gameObject.SetActive(true);
            }

            if (atesEtmeEfekti)
            {
                atesEtmeEfekti.SetActive(true);
            }

            mermiAtisSayac = Time.time + mermiAtisSuresi;
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (atesEtmeEfekti)
                atesEtmeEfekti.SetActive(false);
        }

    }


}
