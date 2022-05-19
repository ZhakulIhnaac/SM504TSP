using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PuzzlePlateBehaviour : MonoBehaviour
    {
        public event Action<PuzzlePlateBehaviour> Invoked;

        [SerializeField] private Material defaultMaterial;
        [SerializeField] private Material successMaterial;
        [SerializeField] private MeshRenderer meshRenderer;

        private bool opened;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerBehaviour>() == null || opened) return;
            
            Invoked?.Invoke(this);
        }

        public void TogglePanel(bool isOpen)
        {
            if (opened == isOpen) return;

            opened = isOpen;

            transform.DOMoveY(isOpen ? -0.1f : 0.1f, 0.1f)
                .SetRelative(true)
                .SetEase(Ease.Linear);

            meshRenderer.material = isOpen ? successMaterial : defaultMaterial;
        }
    }
}