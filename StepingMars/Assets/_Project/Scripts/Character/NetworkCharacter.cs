using System;
using System.Diagnostics;
using Mirror;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace StepingMars._Project.Scripts.Character
{
    // This Class is going to follow the Facade design pattern.
    public class NetworkCharacter : NetworkBehaviour
    {
        [SerializeField] private NetworkCharacterMovement _characterMovement;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private CharacterInteractionController _interactionController;

        public event Action<Vector2> OnFacingDirectionChanges;
        
        void Awake()
        {
            //Initializing The Character
            _characterMovement.Init(_rigidbody2D);
            _interactionController.Init(this);
        }

        private void Update()
        {
            if (!isLocalPlayer)
                return;

            ProcessInput();
        }

        private void ProcessInput()
        {

            
            Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            OnFacingDirectionChanges?.Invoke(movementVector.normalized); //TODO: This is not correct, when there is not an input then is not facing anywhere
            _characterMovement.Move(movementVector);
            FlipSpriteIfNeeded(movementVector);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _interactionController.TryInteraction(movementVector);
            }
        }

        private void FlipSpriteIfNeeded(Vector2 movementVector)
        {
            // TODO: This only works for two sided movement. If we want 4 direction movement we need to changes this.
            float dotProductWithRightVector = Vector2.Dot(movementVector.normalized, Vector2.right);
            if (dotProductWithRightVector == 0)
                return;
            
            _spriteRenderer.flipX = dotProductWithRightVector < 0;
        }
    }
}
