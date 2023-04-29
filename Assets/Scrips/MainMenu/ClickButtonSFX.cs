using UnityEngine;
using UnityEngine.Audio;

public class ClickButtonSFX : MonoBehaviour
{
    [SerializeField] AudioSource ButtonClickSFX;

    public void ButtonCLick()
    {
        ButtonClickSFX.Play();
    }
}
