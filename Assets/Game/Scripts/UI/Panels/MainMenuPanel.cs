using BugfixGames.BugfixGamesGameCycle.Runtime.Scripts;
using BugFixGames.BugFixGamesLocalization.Scripts.Controller;
using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using BugFixGames.BugFixGamesUi.Runtime.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Panels
{
    public class MainMenuPanel : BfgPanelBase
    {
        public override string ContextKey => nameof(MainMenuPanel);

        [SerializeField] private Button continueButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button levelsButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button settingsButton;
        
        [SerializeField] private TextMeshProUGUI continueButtonText;
        [SerializeField] private TextMeshProUGUI newGameButtonText;
        [SerializeField] private TextMeshProUGUI levelsButtonText;
        [SerializeField] private TextMeshProUGUI exitButtonText;

        public override void Initialize()
        {
            base.Initialize();

            continueButton.onClick.AddListener(OnContinueButtonClicked);
            newGameButton.onClick.AddListener(OnNewGameButtonClicked);
            levelsButton.onClick.AddListener(OnLevelsButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            
            continueButtonText.text = BfgLocalizationController.Instance.Translate("continue");
            newGameButtonText.text = BfgLocalizationController.Instance.Translate("newgame");
            levelsButtonText.text = BfgLocalizationController.Instance.Translate("levels");
            exitButtonText.text = BfgLocalizationController.Instance.Translate("exit");
        }

        private void OnContinueButtonClicked()
        {
            BfgGameController.Instance.LoadNextLevel();
        }

        private void OnNewGameButtonClicked()
        {
            PlayerPrefs.DeleteAll();
            BfgGameController.Instance.LoadNextLevel();
        }

        private void OnLevelsButtonClicked()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(LevelsPanel));
            Close();
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
        }

        private void OnSettingsButtonClicked()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(SettingsPanel));
            Close();
        }
    }
}