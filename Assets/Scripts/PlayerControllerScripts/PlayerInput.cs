using UnityEngine;

    
namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameObject _bonus;
        [SerializeField] private GameObject _textSpeedUp;
        [SerializeField, Range(0, 10)] private float _speed = 2.0f;
        private Rigidbody _playerRigidbody;
        private Vector3 _movement;
        private float _currentTime;

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }        

        private void Update()
        {
            KeyboardControl();
        }  
        
        private void FixedUpdate()
        {
            MoveCharacter();
        }

        private void MoveCharacter()
        {
            _playerRigidbody.AddForce(_movement);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("SpeedBonus"))
            {
                SpeedBonus();
            }       
        }

        private void KeyboardControl()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HorizontalAxis);
            float Vertical = Input.GetAxis(GlobalStringVars.VerticalAxis);

            _movement = new Vector3(Vertical, 0, -horizontal);

            _currentTime -= Time.deltaTime;
            if(_currentTime <= 0)
            {
                _textSpeedUp.SetActive(false);
            }
        }

        private void SpeedBonus()
        {  
            _currentTime = 5.0f;
            _textSpeedUp.SetActive(true);
            _speed = 10;
            _bonus.SetActive(false);            
        }

        #if UNITY_EDITOR
            [ContextMenu("Reset values")]
            public void ResetValues()
            {
                _speed = 2;
            }
        #endif
    }
}