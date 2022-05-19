using System;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Behaviours;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class PuzzleController : MonoBehaviour
    {
        [SerializeField] private PuzzlePlateBehaviour[] puzzlePlates;
        [SerializeField] private PuzzlePlateBehaviour[] puzzlePlatesSuccessOrder;
        [SerializeField] private Transform lockFences;

        private List<PuzzlePlateBehaviour> platesSuccessed = new List<PuzzlePlateBehaviour>() ;
        private int successCounterIndex = 0;
        private bool unlocked;

        public PuzzlePlateBehaviour[] PuzzlePlatesSuccessOrder => puzzlePlatesSuccessOrder;
        
        private void Awake()
        {
            foreach (var puzzlePlate in puzzlePlates)
            {
                puzzlePlate.Invoked += OnPlateInvoked;
            }
        }

        private void OnPlateInvoked(PuzzlePlateBehaviour plateInvoked)
        {
            if (puzzlePlatesSuccessOrder[successCounterIndex] == plateInvoked)
            {
                CollectPlateSuccess(plateInvoked, true);
                plateInvoked.TogglePanel(true);
                successCounterIndex++;

                if (successCounterIndex != puzzlePlatesSuccessOrder.Length) return;
                
                ToggleLock();
            }
            else
            {
                successCounterIndex = 0;
                
                foreach (var puzzlePlate in platesSuccessed)
                {
                    puzzlePlate.TogglePanel(false);
                }
                
                platesSuccessed.Clear();
            }
        }

        private void OnDestroy()
        {
            foreach (var puzzlePlate in puzzlePlates)
            {
                puzzlePlate.Invoked -= OnPlateInvoked;
            }
        }

        public void ToggleLock()
        {
            lockFences.DOMoveY(-3.95f, 0.5f)
                .SetRelative(true)
                .SetEase(Ease.Linear);
            
            foreach (var puzzlePlate in puzzlePlates)
            {
                puzzlePlate.Invoked -= OnPlateInvoked;
            }
        }
        
        private void CollectPlateSuccess(PuzzlePlateBehaviour plateToCollect, bool isCollected)
        {
            if (isCollected)
            {
                if(!platesSuccessed.Contains(plateToCollect)) platesSuccessed.Add(plateToCollect);
            }
            else
            {
                if(platesSuccessed.Contains(plateToCollect)) platesSuccessed.Remove(plateToCollect);
            }
        }
    }
}