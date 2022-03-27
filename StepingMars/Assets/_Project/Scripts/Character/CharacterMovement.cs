using UnityEngine;

namespace StepingMars._Project.Scripts.Character
{
    public class CharacterMovement: MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private Rigidbody2D _rigidbody2D;
        
        public void Init(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void Move(Vector2 movementVector)
        {
            _rigidbody2D.velocity = movementVector.normalized * _movementSpeed;
        }
    }
}