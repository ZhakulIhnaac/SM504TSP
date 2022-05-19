using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationBehaviour playerAnim;
        [SerializeField] private Rigidbody selfRigidbody;
        
        private const float MovementThreshold = 0.1f;
        private const float MovementSpeed = 150f;
        
        public Joystick JoyStick;

        private Vector3 _moveDirection;
        
        public void Initialize()
        {
            Subscribe();
        }
        
        private void Subscribe()
        {
        }

        private void UnSubscribe()
        {
        }
        
        private void FixedUpdate()
        {
            PlayerMove();
        }
        
        private void PlayerMove()
        {
            if (new Vector2(JoyStick.Horizontal, JoyStick.Vertical).magnitude < MovementThreshold)
            {
                playerAnim.Walk(false);
                selfRigidbody.velocity = Vector3.zero;
                return;
            }

            _moveDirection = Vector3.forward * JoyStick.Vertical + Vector3.right * JoyStick.Horizontal;
            var speedVector = _moveDirection * (Time.deltaTime * MovementSpeed);
            playerAnim.Walk(true);
            transform.forward = _moveDirection;
            selfRigidbody.velocity = new Vector3(speedVector.x, selfRigidbody.velocity.y, speedVector.z);
        }
    }
}
