using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace StepingMars._Project.Scripts.Character
{
    // This Class is going to follow the Facade design pattern.
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private CharacterInteractionController _interactionController;

        
        void Awake()
        {
            //Initializing The Character
            _characterMovement.Init(_rigidbody2D);
        }

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            _characterMovement.Move(movementVector);
            FlipSpriteIfNeeded(movementVector);
        }

        private void FlipSpriteIfNeeded(Vector2 movementVector)
        {
            float dotProductWithRightVector = Vector2.Dot(movementVector.normalized, Vector2.right);
            if (dotProductWithRightVector == 0)
                return;
            
            _spriteRenderer.flipX = dotProductWithRightVector < 0;
        }
    }
}
