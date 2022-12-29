using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyBox;



public class Fader : MonoBehaviour
{
    [Foldout("Fading",true)]
    [Range(0.1f,10f)]public float FadeTime = 1f;

    [SerializeField] private bool FadeOutOnStart;
    [SerializeField] private bool FadeInOnTeleport;
    [SerializeField] private Image FadeImage;

    [Foldout("Audio", true)]
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip FadeInSound;
    [SerializeField] private AudioClip FadeOutSound;


    public static Fader _Fader;

    void Start()
    {
        if(_Fader==null)_Fader = this;
        if (FadeOutOnStart)
        { 
            FadeImage.DOFade(1, 0f);
            if (_AudioSource != null)
            {
                _AudioSource.clip = FadeInSound;
                _AudioSource.Play();
            }
            FadeImage.DOFade(0, FadeTime);
        }
    }

    public void FadeOut(string Scene)
    {
        if (FadeInOnTeleport)
        {
            FadeImage.DOFade(0, 0);
            if (_AudioSource != null)
            {
                _AudioSource.clip = FadeOutSound;
                _AudioSource.Play();
            }
            FadeImage.DOFade(1, FadeTime).OnComplete(()=> { SceneManager.LoadSceneAsync(Scene);});
        }
        else
        {
            SceneManager.LoadScene(Scene);
        }
    }


}
