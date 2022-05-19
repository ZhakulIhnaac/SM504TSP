using System;
using BugfixGames.BugfixGamesGameCycle.Runtime.Scripts;
using BugFixGames.BugFixGamesLocalization.Scripts.Controller;
using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using Game.Scripts.UI.Panels;
using UnityEngine;
using Utils.Singleton;

namespace Game.Scripts.Controllers
{
    public class ScapeFromMonGameManager : SingletonMonoBehaviour<ScapeFromMonGameManager>
    {
        private void Awake()
        {
            BfgLocalizationController.Instance.Initialize();
            BfgUIController.Instance.Initialize();
            BfgGameController.Instance.Initialize();
            SoundController.Instance.Initialize();
        }

        private void Start()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(MainMenuPanel));
        }
    }
}