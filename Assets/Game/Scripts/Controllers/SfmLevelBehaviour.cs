using System;
using Game.Scripts.Behaviours;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class SfmLevelBehaviour : BfgLevelBehaviourBase
    {
        [SerializeField] private GateBehaviour[] gates;

        private int _openCount;
        
        public override void Initialize()
        {
            base.Initialize();
            Subscribe();
        }

        private void Subscribe()
        {
            foreach (var gate in gates)
            {
                gate.Opened += OnGateOpened;
            }
        }
        
        private void UnSubscribe()
        {
            foreach (var gate in gates)
            {
                gate.Opened -= OnGateOpened;
            }
        }

        private void OnGateOpened()
        {
            _openCount++;

            if (_openCount == gates.Length) Complete(true);
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }
    }
}
