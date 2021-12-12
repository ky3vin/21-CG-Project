using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScripts : MonoBehaviour
{

    public AudioClip Abyss, Space, Savannah;
    public AudioSource audioSource;
    public Button AbyssButton, SavannahButton, SpaceButton;

    public void PlayGame()
    {
        if(this.transform.GetComponent<Button>() == AbyssButton)
        {
            SceneManager.LoadScene("CharacterMenu");
        }
        else if (this.transform.GetComponent<Button>() == SpaceButton)
        {
            SceneManager.LoadScene("SpaceScene");
        }
        else if (this.transform.GetComponent<Button>() == SavannahButton)
        {
            SceneManager.LoadScene("ForestScene");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlaySounds()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

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
    public void QuitSounds()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.Stop();
    }
}
