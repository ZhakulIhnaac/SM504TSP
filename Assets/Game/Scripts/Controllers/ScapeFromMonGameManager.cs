using System;
using BugfixGames.BugfixGamesGameCycle.Runtime.Scripts;
using BugFixGames.BugFixGamesLocalization.Scripts.Controller;
using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using Game.Scripts.UI.Panels;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class ScapeFromMonGameManager : MonoBehaviour
    {
        private void Awake()
        {
            BfgUIController.Instance.Initialize();
            BfgGameController.Instance.Initialize();
            SoundController.Instance.Initialize();
            BfgLocalizationController.Instance.Initialize();
        }

        private void Start()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(MainMenuPanel));
        }
    }
}
