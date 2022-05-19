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
        [SerializeField] private Collider collider;

        public void Open()
        {
            Destroy(canvas);
            Destroy(collider);
            
            leftGate.transform.DORotate(new Vector3(0f, -90f, 0f), 0.3f)
                .SetRelative(true);
            
            rightGate.transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f)
                .SetRelative(true);
            
            Opened?.Invoke();
        }
    }
}
