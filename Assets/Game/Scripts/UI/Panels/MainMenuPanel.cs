using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using BugFixGames.BugFixGamesUi.Runtime.Scripts;
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

        public override void Initialize()
        {
            base.Initialize();

            continueButton.onClick.AddListener(OnContinueButtonClicked);
            newGameButton.onClick.AddListener(OnNewGameButtonClicked);
            levelsButton.onClick.AddListener(OnLevelsButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        private void OnContinueButtonClicked()
        {
            throw new System.NotImplementedException();
        }

        private void OnNewGameButtonClicked()
        {
            throw new System.NotImplementedException();
        }

        private void OnLevelsButtonClicked()
        {
            throw new System.NotImplementedException();
        }

        private void OnExitButtonClicked()
        {
            throw new System.NotImplementedException();
        }

        private void OnSettingsButtonClicked()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(SettingsPanel));
            Close();
        }
    }
}