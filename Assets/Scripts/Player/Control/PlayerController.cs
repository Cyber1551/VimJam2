using System;
using UnityEngine;

namespace Player.Control
{
    public class PlayerController: MonoBehaviour
    {
        private static readonly int Magnitude = Animator.StringToHash("InputMagnitude");
        public static PlayerController Instance;
        
        private float _velocity;
        private Animator _anim;
        private Vector3 _moveVector;
        private Vector3 _desiredMoveDirection;
        private float _turnVel;
        private InputManager _input;
        
        private float _inputZ;
        private float _inputX;

        public bool canReceiveInput;
        public bool inputReceived;

        [SerializeField] float desiredRotationSpeed = 0.1f;
        [SerializeField] bool blockRotationPlayer;
        [SerializeField] float allowPlayerRotationAmount = 0.3f;

        public GameObject test;
        public GameObject test2;
        
        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            _input = InputManager.Instance;
            _anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            PlayerMovement();
            if (Input.GetKeyUp(KeyCode.P))
            {
                _anim.SetBool("Connected", !_anim.GetBool("Connected"));
            }

            PlayerCombo();
        }

        private void FreeFormMoveAndRotation()
        {
            if (!Camera.main) return;
            var camTransform = Camera.main.transform;
            var forward = camTransform.forward;
            var right = camTransform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();
            _desiredMoveDirection = forward * _inputZ + right * _inputX;
            if (!blockRotationPlayer)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_desiredMoveDirection), desiredRotationSpeed);
            }
        }
        

        private void PlayerMovement()
        {

            _inputZ = _input.Vertical;
            _inputX = _input.Horizontal;
            
            _velocity = new Vector2(_inputX, _inputZ).sqrMagnitude;

            if (_velocity > allowPlayerRotationAmount)
            {
                _anim.SetFloat(Magnitude, _velocity, 0.0f, Time.fixedDeltaTime);
                FreeFormMoveAndRotation();
            }
            else if (_velocity < allowPlayerRotationAmount)
            {
                _anim.SetFloat(Magnitude, _velocity, 0.0f, Time.fixedDeltaTime);
            }
        }

        private void PlayerCombo()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (canReceiveInput)
                {
                    inputReceived = true;
                    canReceiveInput = false;
                }
            }
        }
        

        #region Animation Events

        private void TestEvent()
        {
            var go = Instantiate(test, transform.position + transform.forward * 1, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 180f)));
            Destroy(go, 0.75f);
        }
        private void TestEvent2()
        {
            var go = Instantiate(test2, transform.position + transform.forward * 1, Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0)));
            Destroy(go, 0.75f);
        }
        #endregion
    }
}