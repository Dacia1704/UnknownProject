using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set;}
    [SerializeField] private AudioSourceSO AudioSourceSO;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
    }
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


    #region Change Volumn
    public void SetMasterVolumn(float value)
    {
        AudioSourceSO.MasterMixerGroup.audioMixer.SetFloat("Master",value);
    }
    public void SetBGMVolumn(float value)
    {
        AudioSourceSO.BgmMixerGroup.audioMixer.SetFloat("BGM",value);
    }
    public void SetSFXVolumn(float value)
    {
        AudioSourceSO.SfxMixerGroup.audioMixer.SetFloat("SFX",value);
    }

    public float GetMasterVolum()
    {
        float value;
        AudioSourceSO.MasterMixerGroup.audioMixer.GetFloat("Master",out value);
        return value;
    }    
    public float GetSFXVolum()
    {
        float value;
        AudioSourceSO.SfxMixerGroup.audioMixer.GetFloat("SFX",out value);
        return value;
    }   
    public float GetBGMVolum()
    {
        float value;
        AudioSourceSO.BgmMixerGroup.audioMixer.GetFloat("BGM",out value);
        return value;
    }       
    #endregion





}
