using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class KeyBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            transform.DORotate(new Vector3(0f, 360f, 0f), 1f)
                .SetRelative(true)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }
    }
}
