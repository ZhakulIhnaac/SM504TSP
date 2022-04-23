using System.Collections;
using System.Collections.Generic;
using BfgPlayerData.Scripts;
using BfgUtils.Extensions;
using BugFixGames.BugFixGamesUtils.Runtime.Extensions;
using UnityEngine;
using Utils.Singleton;

namespace Game.Scripts.Controllers
{
    public class SoundController : SingletonMonoBehaviour<SoundController>
    {
        [SerializeField] private AudioSource soundEffectAudioSource;
        [SerializeField] private AudioSource musicsAudioSource;
        [SerializeField] private AudioClip[] musics;

        public bool MusicEnabled { get; private set; }
        public bool SoundEffectsEnabled { get; private set; }

        private IEnumerator musicPlaylistCoroutine;

        public void Initialize()
        {
            MusicEnabled = BfgPlayerDataManager.GetBooleanPlayerPref("musicEnabled", true);
            SoundEffectsEnabled = BfgPlayerDataManager.GetBooleanPlayerPref("soundEffectsEnabled", true);

            if (MusicEnabled) PlayMusic();
        }

        #region Music

        public void ToggleMusic(bool isEnabled)
        {
            this.BfgLog($"Sound enabled: {isEnabled}");
            MusicEnabled = !MusicEnabled;
            BfgPlayerDataManager.SetBooleanPlayerPref("musicEnabled", isEnabled);
            
            if (isEnabled)
            {
                PlayMusic();
            }
            else
            {
                StopMusic();
            }
        }

        private void PlayMusic()
        {
            if (musicPlaylistCoroutine != null) StopCoroutine(musicPlaylistCoroutine);

            musicPlaylistCoroutine = PlayMusicCoroutine();
            StartCoroutine(musicPlaylistCoroutine);

            IEnumerator PlayMusicCoroutine()
            {
                musics.Shuffle();
                for (int i = 0; i < musics.Length; i++)
                {
                    var clip = musics[i];
                    musicsAudioSource.clip = clip;
                    musicsAudioSource.Play();
                    yield return new WaitForSeconds(clip.length + 2f);
                }
            }
        }

        private void StopMusic()
        {
            musicsAudioSource.Stop();
            if (musicPlaylistCoroutine != null) StopCoroutine(musicPlaylistCoroutine);
        }

        #endregion

        #region Sound Effects

        private void PlaySoundEffect(AudioClip clip)
        {
            if (SoundEffectsEnabled) soundEffectAudioSource.PlayOneShot(clip);
        }

        #endregion

        #region Crowd Sound

        public void ToggleSound(bool isEnabled)
        {
            soundEffectAudioSource.volume = isEnabled ? 1 : 0;
        }

        #endregion
    }
}