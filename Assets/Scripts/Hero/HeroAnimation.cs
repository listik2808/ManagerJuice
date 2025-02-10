using UnityEngine;

namespace Scripts.Hero
{
    public class HeroAnimation : MonoBehaviour
    {
        private const string Speed = "Speed";
        private Animator _animator;
        private HeroMove _heroMove;

        public void Constroct(HeroMove heroMove)
        {
            _heroMove = heroMove;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat(Speed,_heroMove.CharacterController.velocity.magnitude,0.1f,Time.deltaTime);
        }
    }
}