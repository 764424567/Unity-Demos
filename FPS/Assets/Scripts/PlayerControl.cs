using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private bool m_IsWalking;
    [SerializeField] private float m_WalkSpeed;
    [SerializeField] private float m_RunSpeed;
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private float m_StickToGroundForce;
    [SerializeField] private float m_GravityMultiplier;
    [SerializeField] private MouseLook m_MouseLook;

    private Camera m_Camera;
    private bool m_Jump;
    private Vector2 m_Input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController m_CharacterController;
    private bool m_PreviouslyGrounded;
    private bool m_Jumping;

    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_JumpSound;           // 角色离开地面时播放的声音。
    [SerializeField] private AudioClip m_LandSound;           // 当角色触碰地面时播放的声音。

    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_Jumping = false;
        m_MouseLook.Init(transform, m_Camera.transform);
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RotateView();
        // 跳转状态需要在这里读取，以确保它不会丢失
        if (!m_Jump)
        {
            m_Jump = Input.GetButtonDown("Jump");
        }

        if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
        {
            PlayLandingSound();
            m_MoveDir.y = 0f;
            m_Jumping = false;
        }
        if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
        {
            m_MoveDir.y = 0f;
        }
        m_PreviouslyGrounded = m_CharacterController.isGrounded;
    }
    private void PlayLandingSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
    }

    private void PlayJumpSound()
    {
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }

    private void FixedUpdate()
    {
        float speed;
        GetInput(out speed);
        //始终沿着相机向前移动，因为这是它瞄准的方向
        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

        //获取被接触曲面的法线以沿其移动
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
                           m_CharacterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        m_MoveDir.x = desiredMove.x * speed;
        m_MoveDir.z = desiredMove.z * speed;

        if (m_CharacterController.isGrounded)
        {
            m_MoveDir.y = -m_StickToGroundForce;
            if (m_Jump)
            {
                m_MoveDir.y = m_JumpSpeed;
                m_Jump = false;
                m_Jumping = true;
                PlayJumpSound();
            }
        }
        else
        {
            m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        }
        m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);

        UpdateCameraPosition(speed);

        m_MouseLook.UpdateCursorLock();
    }


    private void UpdateCameraPosition(float speed)
    {
        Vector3 newCameraPosition;
        if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
        {
            m_Camera.transform.localPosition = newCameraPosition = m_Camera.transform.localPosition;
        }
        else
        {
            newCameraPosition = m_Camera.transform.localPosition;
        }
        m_Camera.transform.localPosition = newCameraPosition;
    }


    private void GetInput(out float speed)
    {
        // 读取输入的值
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
        // 在独立构建中，步行/跑步速度通过按键进行修改。
        //跟踪角色是在行走还是在跑步
        m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif
        // set the desired speed to be walking or running
        speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
        m_Input = new Vector2(horizontal, vertical);

        // 如果组合长度超过1，则规范化输入：
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }
    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }

    public void Hit()
    {
        Debug.Log("被击中");
        //扣血
        HealthSystem hs = GetComponent<HealthSystem>();
        if (hs != null)
        {
            hs.SubstractHealth(10);
            if (hs.CurrentHp == 0)
                return;
        }
    }

    void Death()
    {
        Debug.Log("死亡");
        Debug.Log("游戏结束");
    }
}