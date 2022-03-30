using System;
using UnityEditor;
using UnityEngine;

namespace StepingMars._Project.Scripts.Character
{
    public class CharacterInteractionController: MonoBehaviour
    {
        [SerializeField] private float _interactionForwardOffset;
        [SerializeField] private float _interactionArea;

        private Vector2 _facingDirection;
        private Collider2D[] _potentialInteractions;
        private NetworkCharacter _character;
        
        public void Init(NetworkCharacter _character)
        {
            this._character = _character;
            _character.OnFacingDirectionChanges += UpdateCurrentFacingDirection;
            _potentialInteractions = new Collider2D[10];
        }

        private void UpdateCurrentFacingDirection(Vector2 direction)
        {
            _facingDirection = direction;
        }

        public void TryInteraction(Vector2 facingDirection)
        {
            Vector2 positionToCheck = (Vector2)this.transform.position + (facingDirection.normalized * _interactionForwardOffset);
            Physics2D.OverlapCircleNonAlloc(positionToCheck, _interactionArea, _potentialInteractions);
            foreach (Collider2D collider in _potentialInteractions)
            {
                var interactable = collider?.GetComponent<Interactable>();

                if (!interactable)
                    return;
                
                interactable.Interact(this.transform);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Vector2 planeVector = _facingDirection * _interactionForwardOffset;
            Vector3 spacialVector = new Vector3(planeVector.x, planeVector.y, 0f);
            Gizmos.DrawSphere(this.transform.position + spacialVector, _interactionArea);
        }
    }
}