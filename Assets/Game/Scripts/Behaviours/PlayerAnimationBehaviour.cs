using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerAnimationBehaviour : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public void Walk(bool walk)
        {
            anim.SetBool(IsWalking, walk);
        }
    }
}