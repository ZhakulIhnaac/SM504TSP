using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationBehaviour playerAnim;
        [SerializeField] private Rigidbody selfRigidbody;
        
        private List<KeyBehaviour> keys = new List<KeyBehaviour>();
        
        private const float MovementThreshold = 0.1f;
        private const float MovementSpeed = 300f;
        
        public Joystick JoyStick;

        private Vector3 _moveDirection;
        
        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void OnTriggerEnter(Collider other)
        {
            ////////////////KEY/////////////////
            var keyObject = other.GetComponent<KeyBehaviour>();
            
            if (keyObject != null)
            {
                CollectKeyToggle(keyObject, true);
                Destroy(keyObject.gameObject);
            }
            
            ////////////////DOOR/////////////////
            var gateObject = other.GetComponent<GateBehaviour>();
            
            if (gateObject != null && keys.Count == gateObject.requiredKeys)
            {
                // CollectKeyToggle(keys[^1], false);
                gateObject.Open(); 
            }
        }

        private void CollectKeyToggle(KeyBehaviour keyToCollect, bool isCollected)
        {
            if (isCollected)
            {
                if(!keys.Contains(keyToCollect)) keys.Add(keyToCollect);
            }
            else
            {
                if(keys.Contains(keyToCollect)) keys.Remove(keyToCollect);
            }
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
