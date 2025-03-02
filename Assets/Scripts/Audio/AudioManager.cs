using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set;}
    [SerializeField] private AudioSourceSO AudioSourceSO;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        SaveLoadManager.Instance.OnGameDataLoaded += LoadVolumnData;
    }

    private void LoadVolumnData(GameData gameData)
    {
        SetMasterVolumn(gameData.GlobalAudioVolume);
        SetBGMVolumn(gameData.BMGAudioVolume);
        SetSFXVolumn(gameData.SFXAudioVolume);
    }

    public void LoadVolumnData(float global, float bgm, float sfx) 
    {
        SetMasterVolumn(global);
        SetBGMVolumn(bgm);
        SetSFXVolumn(sfx);
    }

    #region PlayAudio
    public void PlayPlayerAttackAudio(AudioSource audioSource,bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            audioSource.clip = AudioSourceSO.PlayerAttack1Audio;
        } else if (random == 2)
        {
            audioSource.clip = AudioSourceSO.PlayerAttack2Audio;
        }
        else
        {
            audioSource.clip = AudioSourceSO.PlayerAttack3Audio;
        }
        audioSource.Play();
    }
    public void PlayPlayerHitAudio(AudioSource audioSource,bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            audioSource.clip = AudioSourceSO.PlayerHit1Audio;
        } else if (random == 2)
        {
            audioSource.clip = AudioSourceSO.PlayerHit2Audio;
        }
        else
        {
            audioSource.clip = AudioSourceSO.PlayerHit3Audio;
        }
        audioSource.Play();
    }
    public void PlayPlayerDeathAudio(AudioSource audioSource, bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        audioSource.clip = AudioSourceSO.PlayerDeathAudio;
        audioSource.Play();
    }
    public void PlayBulletHitAudio(AudioSource audioSource, bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        audioSource.clip = AudioSourceSO.BulletHitAudio;
        audioSource.Play();
    }
    public void PlayButtonAudio(AudioSource audioSource,bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        audioSource.clip = AudioSourceSO.ButtonClickAudio;
        audioSource.Play();
    }
    public void PlayBeginDragAudio(AudioSource audioSource,bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        audioSource.clip = AudioSourceSO.BeginDragAudio;
        audioSource.Play();
    }
    public void PlayEndDragAudio(AudioSource audioSource,bool isLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = isLoop;
        audioSource.clip = AudioSourceSO.EndDragAudio;
        audioSource.Play();
    }
    public void StopAudio(AudioSource audioSource)
    {
        audioSource.Stop();
    }
    #endregion

    #region Change Volumn
    public void SetMasterVolumn(float value)
    {
        value = value * 100 - 80;
        AudioSourceSO.MasterMixerGroup.audioMixer.SetFloat("MasterVolumn",value);
    }
    public void SetBGMVolumn(float value)
    {
        value = value * 100 - 80;
        AudioSourceSO.BgmMixerGroup.audioMixer.SetFloat("BgmVolumn",value);
    }
    public void SetSFXVolumn(float value)
    {
        value = value * 100 - 80;
        AudioSourceSO.SfxMixerGroup.audioMixer.SetFloat("SfxVolumn",value);
    }

    public float GetMasterVolumn()
    {
        float value;
        AudioSourceSO.MasterMixerGroup.audioMixer.GetFloat("MasterVolumn",out value);
        return (value + 80)/100;
    }    
    public float GetSFXVolum()
    {
        float value;
        AudioSourceSO.SfxMixerGroup.audioMixer.GetFloat("SfxVolumn",out value);
        return (value + 80)/100;
    }   
    public float GetBGMVolum()
    {
        float value;
        AudioSourceSO.BgmMixerGroup.audioMixer.GetFloat("BgmVolumn",out value);
        return (value + 80)/100;
    }       
    #endregion





}
