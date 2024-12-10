using System.Collections;
using UnityEngine;
using DG.Tweening;


public class PickUpManager : MonoBehaviour
{
    public static PlayerHealthController instance;

    public enum PickUpItems
    {
        Zirh,
        Can,

    }

    public PickUpItems pickUpItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickUpItem == PickUpItems.Zirh)
            {
                PlayerHealthController.instance.ZirhiArtirFNC(1);

                Destroy(gameObject);
            }
            else if (pickUpItem == PickUpItems.Can)
        { 
                PlayerHealthController.instance.CaniArtirFNC(1);
            Destroy(gameObject);
        }
    }
    }
}
