using BfgPlayerData.Scripts;
using BugfixGames.BugfixGamesGameCycle.Runtime.Scripts;
using BugFixGames.BugFixGamesLocalization.Scripts.Controller;
using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using BugFixGames.BugFixGamesUi.Runtime.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Panels
{
    public class LevelsPanel : BfgPanelBase
    {
        public override string ContextKey => nameof(LevelsPanel);

        [SerializeField] private Button level1Button;
        [SerializeField] private Button level2Button;
        [SerializeField] private Button level3Button;
        [SerializeField] private Button returnMenuButton;

        [SerializeField] private TextMeshProUGUI level1ButtonText;
        [SerializeField] private TextMeshProUGUI level2ButtonText;
        [SerializeField] private TextMeshProUGUI level3ButtonText;
        [SerializeField] private TextMeshProUGUI returnMenuButtonText;

        public override void Initialize()
        {
            base.Initialize();
            level1Button.onClick.AddListener(() => OnLevelButtonClicked(1));
            level2Button.onClick.AddListener(() => OnLevelButtonClicked(2));
            level3Button.onClick.AddListener(() => OnLevelButtonClicked(3));
            returnMenuButton.onClick.AddListener(() => OnCloseButtonClicked());

            level1ButtonText.text = BfgLocalizationController.Instance.Translate("level1");
            level2ButtonText.text = BfgLocalizationController.Instance.Translate("level2");
            level3ButtonText.text = BfgLocalizationController.Instance.Translate("level3");
            returnMenuButtonText.text = BfgLocalizationController.Instance.Translate("back");
        }

        private void OnLevelButtonClicked(int levelNumber)
        {
            BfgPlayerDataManager.SetIntPlayerPref("currentLevel", levelNumber);
            BfgGameController.Instance.LoadNextLevel();
            Close();
        }

        private void OnCloseButtonClicked()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(MainMenuPanel));
            Close();
        }
    }
}