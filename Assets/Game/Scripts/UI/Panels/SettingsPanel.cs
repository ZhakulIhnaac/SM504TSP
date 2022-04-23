using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using BugFixGames.BugFixGamesUi.Runtime.Scripts;
using Game.Scripts.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Panels
{
    public class SettingsPanel : BfgPanelBase
    {
        public override string ContextKey => nameof(SettingsPanel);
        
        // [SerializeField] private Button toggleSoundButton;
        [SerializeField] private Button toggleMusicButton;
        // [SerializeField] private Image soundIcon;
        [SerializeField] private Image musicIcon;
        [SerializeField] private Button backButton;
        // [SerializeField] private Sprite soundEnabledIcon;
        // [SerializeField] private Sprite soundDisabledIcon;
        [SerializeField] private Sprite musicEnabledIcon;
        [SerializeField] private Sprite musicDisabledIcon;

        public override void Initialize()
        {
            base.Initialize();
            
            // toggleSoundButton.onClick.AddListener(OnSoundEnabledClicked);
            toggleMusicButton.onClick.AddListener(OnMusicEnabledClicked);
            backButton.onClick.AddListener(OnCloseButtonClicked);
        }

        // private void OnSoundEnabledClicked()
        // {
        //     SoundController.Instance.ToggleSound(!SoundController.Instance.soundEffectsEnabled);
        //     SoundController.Instance.soundEffectsEnabled = !SoundController.Instance.soundEffectsEnabled;
        //     soundIcon.sprite = SoundController.Instance.soundEffectsEnabled ? soundEnabledIcon : soundDisabledIcon;
        // }
        
        private void OnMusicEnabledClicked()
        {
            SoundController.Instance.ToggleMusic(!SoundController.Instance.MusicEnabled);
            musicIcon.sprite = SoundController.Instance.MusicEnabled ? musicEnabledIcon : musicDisabledIcon;
        }

        private void OnCloseButtonClicked()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(MainMenuPanel));
            Close();
        }

        protected override void ResetFrame()
        {
            base.ResetFrame();
            musicIcon.sprite = SoundController.Instance.MusicEnabled ? musicEnabledIcon : musicDisabledIcon;
        }
    }
}