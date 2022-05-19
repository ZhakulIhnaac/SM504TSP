using BugFixGames.BugFixGamesLocalization.Scripts.Controller;
using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using BugFixGames.BugFixGamesUi.Runtime.Scripts;
using Game.Scripts.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Panels
{
    public class SettingsPanel : BfgPanelBase
    {
        public override string ContextKey => nameof(SettingsPanel);
        
        [SerializeField] private Button toggleMusicButton;
        [SerializeField] private Button backButton;
        [SerializeField] private TMP_Dropdown languageSelectionDropdown;
        [SerializeField] private Image musicIcon;
        [SerializeField] private Sprite musicEnabledIcon;
        [SerializeField] private Sprite musicDisabledIcon;
        
        [SerializeField] private TextMeshProUGUI backButtonText;

        public override void Initialize()
        {
            base.Initialize();
            
            toggleMusicButton.onClick.AddListener(OnMusicEnabledClicked);
            backButton.onClick.AddListener(OnCloseButtonClicked);
            languageSelectionDropdown.onValueChanged.AddListener((value) => OnLanguageChanged(value));

            languageSelectionDropdown.value = BfgLocalizationController.Instance.GetSelectedLanguageIndex();
            
            backButtonText.text = BfgLocalizationController.Instance.Translate("back");
        }
        
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

        public void OnLanguageChanged(int index)
        {
            
            Debug.Log(index);
            switch (index)
            {
                case 0:
                    BfgLocalizationController.Instance.SetDictionary(SystemLanguage.English);
                    break;
                case 1:
                    BfgLocalizationController.Instance.SetDictionary(SystemLanguage.Turkish);
                    break;
            }
        }
    }
}