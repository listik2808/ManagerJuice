using Scripts.Infrastructure.Services.Input;
using Scripts.Infrastructure;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        private Camera _camera;
        private IInputServices _inputServices;

        public CharacterController CharacterController => _characterController;
        public float MovementSpeed => _movementSpeed;

        private void Awake()
        {
            _inputServices = Game.InputServices;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;
            if (_inputServices.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_inputServices.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;
            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}