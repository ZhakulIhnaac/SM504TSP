using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class GateBehaviour : MonoBehaviour
    {
        public event Action Opened;
        
        [SerializeField] private Transform leftGate;
        [SerializeField] private Transform rightGate;
        [SerializeField] private GameObject canvas;
        [SerializeField] private Transform spaceShipPart;

        public int requiredKeys;
        
        public void Open()
        {
            Destroy(canvas);
            
            leftGate.transform.DORotate(new Vector3(0f, -90f, 0f), 0.3f)
                .SetRelative(true);
            
            rightGate.transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f)
                .SetRelative(true);

            spaceShipPart.DOMoveY(50f, 4f)
                .SetEase(Ease.Linear)
                .SetRelative(true)
                .OnComplete(() => Opened?.Invoke());
        }
    }
}
