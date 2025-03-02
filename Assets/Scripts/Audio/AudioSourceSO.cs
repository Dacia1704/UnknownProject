using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioSourceSO", menuName = "AudioSourceSO", order = 0)]
public class AudioSourceSO : ScriptableObject
{
    [field: Header("Background")]
    [field: SerializeField] public AudioClip FireBgmAudio {get; private set;}
    [field: SerializeField] public AudioClip LeafBgmAudio {get; private set;}
    [field: SerializeField] public AudioClip WaterBgmAudio {get; private set;}
    
    [field: Header("UI")]
    [field: SerializeField] public AudioClip ButtonClickAudio { get; private set; }
    [field: SerializeField] public AudioClip BeginDragAudio { get; private set; }
    [field: SerializeField] public AudioClip EndDragAudio { get; private set; }
    
    [field: Header("Gameplay")]
    [field: SerializeField] public AudioClip PlayerAttack1Audio { get; private set; }
    [field: SerializeField] public AudioClip PlayerAttack2Audio { get; private set; }
    [field: SerializeField] public AudioClip PlayerAttack3Audio { get; private set; }
    [field: SerializeField] public AudioClip PlayerHit1Audio { get; private set; }
    [field: SerializeField] public AudioClip PlayerHit2Audio { get; private set; }
    [field: SerializeField] public AudioClip PlayerHit3Audio { get; private set; }
    [field: SerializeField] public AudioClip PlayerDeathAudio { get; private set; }
    
    [field: SerializeField] public AudioClip BulletHitAudio { get; private set; }
    
    [field: SerializeField] public AudioMixerGroup MasterMixerGroup { get; private set; }
    [field: SerializeField] public AudioMixerGroup BgmMixerGroup { get; private set; }
    [field: SerializeField] public AudioMixerGroup SfxMixerGroup { get; private set; }
}