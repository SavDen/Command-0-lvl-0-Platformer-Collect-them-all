using UnityEngine;
using YG;

public class Move : MonoBehaviour
{
    public Transform _respown;

    static public float InputMobile;
    static public bool DownBombUI;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform BodyPlayer;
    [SerializeField] private Animator _animtor;
    [SerializeField] private AudioSource _audio, _bangBomb;
    [SerializeField] private GameObject timerAds; 

    [SerializeField] private float MovedForce;
    [SerializeField] private float FrigtionForce;
    [SerializeField] private float MaxSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _xEuler = 90;
    [SerializeField] private float speedDown;
    [SerializeField] private float _volumeAudio;

    [SerializeField] private bool IsGrounded, _playerInput = true;



    private void Awake()
    {
        InputMobile = 0;

    }
    private void FixedUpdate()
    {

        //Moved
        if (YandexGame.EnvironmentData.isDesktop)
        {
            float forwardForce = Input.GetAxis("Horizontal");
            if (forwardForce > 0)
                _xEuler = 90f;
            else if (forwardForce < 0)
                _xEuler = 270f;
        }

        else if (YandexGame.EnvironmentData.isMobile || YandexGame.EnvironmentData.isTablet)
        {
            float forwardForce = InputMobile;
            if (forwardForce > 0)
                _xEuler = 90f;
            else if (forwardForce < 0)
                _xEuler = 270f;
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _xEuler, 0), _rotationSpeed);

        float speedMultiplier = 1.0f;

        if (!IsGrounded)
        {
            rb.velocity = new Vector3(0, speedDown, 0);
            speedMultiplier = 0f;
        }

        if (YandexGame.EnvironmentData.isDesktop)
        {
            if (_playerInput)
                rb.AddForce(Input.GetAxis("Horizontal") * MovedForce * speedMultiplier, 0.0f, 0.0f, ForceMode.VelocityChange);
        }

        else if (YandexGame.EnvironmentData.isMobile || YandexGame.EnvironmentData.isTablet)
        {
            if (_playerInput)
                rb.AddForce(InputMobile * MovedForce * speedMultiplier, 0.0f, 0.0f, ForceMode.VelocityChange);
        }

        if (IsGrounded)
        {
            rb.AddForce(-rb.velocity.x * FrigtionForce, 0.0f, 0.0f, ForceMode.VelocityChange);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || InputMobile !=0)
        {
            _audio.volume = _volumeAudio;
            _animtor.SetBool("Move", true);
        }
        else
        {
            _audio.volume = 0;
            _animtor.SetBool("Move", false);
        }

    }
    private void OnCollisionStay(Collision other)
    {
        
       
        if (Vector3.Angle(other.contacts[0].normal, Vector3.up) <= 45.0f)
        {
            
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        IsGrounded = false;
    }

    public void Dead()
    {
        //transform.position = _respown.position;
        timerAds.SetActive(true);
        rb.position = _respown.position;
        _bangBomb.Play();
        _animtor.SetTrigger("Dead");
    }

    public void InputControl()
    {
        if (_playerInput)
            _playerInput = false;
        else
            _playerInput = true;
    }

    public void MobileInput(float input)
    {
        InputMobile =  input;
    }

    public void DownUI(bool down)
    {
        DownBombUI = down;
    }


}