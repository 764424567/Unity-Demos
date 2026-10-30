using UnityEngine;
using System.Collections;

public class CameraMoveGround : MonoBehaviour
{
    public bool isMove = false;
    [SerializeField, Tooltip("旋转速度")]
    public float rotateSpeed = 2f;
    /// <summary>
    /// 角色控制器
    /// </summary>
    private CharacterController character;
    /// <summary>
    /// Y轴旋转最小值
    /// </summary>
    //private float minRotateY = -60f;
    /// <summary>
    /// Y轴旋转最大值
    /// </summary>
    //private float maxRotateY = 60f;
    private float rotationX;
    private float rotationY;
    private Quaternion tmpRotation;
    /// <summary>
    /// 相机旋转平滑度
    /// </summary>
    [Range(1f, 5f)]
    public float rotateLerpValue = 3f;
    private Vector3 move = Vector3.zero;
    [SerializeField, Tooltip("移动速度")]
    public float moveSpeed = 2f;
    [SerializeField, Tooltip("是否使用重力")]
    public bool isUseGravity = true;


    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        rotationX = transform.localEulerAngles.x;
        rotationY = transform.localEulerAngles.y;
    }

    void Update()
    {
        if (isMove)
        {
            if (Input.GetMouseButton(1))
            {
                rotationX -= Input.GetAxis("Mouse Y") * rotateSpeed;
                rotationY += Input.GetAxis("Mouse X") * rotateSpeed;
                tmpRotation = Quaternion.Euler(rotationX, rotationY, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, tmpRotation, Time.deltaTime * rotateLerpValue);
            }
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");
                move.x = moveX * moveSpeed;
                move.z = moveZ * moveSpeed;
                if (isUseGravity)
                {
                    character.SimpleMove(transform.TransformVector(move));
                }
                else
                {
                    move.x = move.x * 0.01f;
                    move.z = move.z * 0.01f;
                    character.Move(transform.TransformVector(move));
                }
            }
        }
    }
}