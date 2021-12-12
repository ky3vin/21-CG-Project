using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class SoundScripts : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip Abyss, Space, Savannah;
    public AudioSource audioSource;
    public Button AbyssButton, SavannahButton, SpaceButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.transform.GetComponent<Button>() == AbyssButton)
        {
            audioSource.PlayOneShot(Abyss);
        }
        else if (this.transform.GetComponent<Button>() == SpaceButton)
        {
            audioSource.PlayOneShot(Space);
        }
        else if (this.transform.GetComponent<Button>() == SavannahButton)
        {
            audioSource.PlayOneShot(Savannah);
        }
    }
}
