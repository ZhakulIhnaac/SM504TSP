using System;
using BugfixGames.BugfixGamesGameCycle.Runtime.Scripts;
using BugFixGames.BugFixGamesLocalization.Scripts.Controller;
using BugfixGames.BugfixGamesUi.Runtime.Scripts;
using Game.Scripts.Behaviours;
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

            BfgGameController.Instance.LevelEnded += OnLevelCompleted;
        }

        private void Start()
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(MainMenuPanel));
        }

        private void OnLevelCompleted(BfgLevelBehaviourBase bfgLevelBehaviourBase, bool isSuccess)
        {
            BfgUIController.Instance.OpenPanelWithName(nameof(MainMenuPanel));
            BfgGameController.Instance.DisposeLevel();
        }
    }
}