using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using NeoFPS.ModularFirearms;
using River;

public class UpdatePitch: MonoBehaviour
{
    [SerializeField] private bool UpdatePitchOnShoot;
    [ReadOnly,SerializeField] private float PitchModifier;
    [ReadOnly, SerializeField] private BaseReloaderBehaviour Reloader;
    [ReadOnly, SerializeField] private int MaxAmmo,CurrentAmmo;

    void Start()
    {
        Reloader = GetComponentInChildren<BaseReloaderBehaviour>();
        if (Reloader != null) 
        {
            MaxAmmo = Reloader.magazineSize;
            CurrentAmmo = MaxAmmo;
            Reloader.OnShoot += OnFire;
            Reloader.OnReload += OnReload;
        }
        AudioManager.instance.Initialize();
    }

    private void OnFire()
    {
        CurrentAmmo--;
        PitchModifier =((float)CurrentAmmo / MaxAmmo);
        PitchModifier = Mathf.Clamp(PitchModifier, 0.1f, 1f);
        UpdateAudioSource(PitchModifier);
    }

    private void OnReload()
    {
        CurrentAmmo = MaxAmmo;
        PitchModifier = 1;
        UpdateAudioSource(PitchModifier);
    }

    void UpdateAudioSource(float Pitch)
    {
        if(UpdatePitchOnShoot) AudioManager.instance.UpdatePitch(Pitch);
    }
}
