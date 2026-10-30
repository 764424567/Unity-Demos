using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Player;
    Vector3 tempPoint = new Vector3(0, 0, 0);
    public float m_speed = 5f;

    void Update()
    {
        //鼠标点击移动
        //PlayerMove_FollowMouse();
        //键盘控制移动
        //PlayerMove_KeyTransform();
        //PlayerMove_KeyTransform2();
        //PlayerMove_KeyRighidbody();
        //PlayerMove_KeyRighidbody2();
        PlayerMove_KeyCharacterController();
        PlayerMove_KeyCharacterController2();
    }

    //角色移动到鼠标点击的位置
    public void PlayerMove_FollowMouse()
    {
        
        //右键点击
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray,out hitInfo))
            {
                tempPoint = hitInfo.point;
            }
        }
        float step = 10 * Time.deltaTime;
        Player.transform.localPosition = Vector3.MoveTowards(Player.transform.localPosition, tempPoint, step);
        Player.transform.LookAt(tempPoint);
    }

    //通过Transform组件 键盘控制移动
    public void PlayerMove_KeyTransform()
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow)) //前
        {
            Player.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow)) //后
        {
            Player.transform.Translate(Vector3.forward * -m_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) //左
        {
            Player.transform.Translate(Vector3.right * -m_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
        {
            Player.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
        }
    }

    //通过Transform组件 键盘控制移动 另一种写法
    public void PlayerMove_KeyTransform2()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下

        Player.transform.Translate(Vector3.forward * vertical * m_speed * Time.deltaTime);//W S 上 下
        Player.transform.Translate(Vector3.right * horizontal * m_speed * Time.deltaTime);//A D 左右
    }

    //通过Rigidbody组件 键盘控制移动 Velocity移动 角色身上需要挂载Rigidbody组件
    public void PlayerMove_KeyRighidbody()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下
        //这个必须分开判断 因为一个物体的速度只有一个
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S))
        {
            Player.GetComponent<Rigidbody>().velocity = Vector3.forward * vertical * m_speed;
        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
        {
            Player.GetComponent<Rigidbody>().velocity = Vector3.right * horizontal * m_speed;
        }
    }

    //通过Rigidbody组件 键盘控制移动 AddForce控制移动 角色身上需要挂载Rigidbody组件
    public void PlayerMove_KeyRighidbody2()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下

        Player.GetComponent<Rigidbody>().AddForce(Vector3.forward * vertical * m_speed);
        Player.GetComponent<Rigidbody>().AddForce(Vector3.right * horizontal * m_speed);
    }

    //通过CharacterController组件 键盘移动物体 SimpleMove控制移动
    public void PlayerMove_KeyCharacterController()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下

        Player.GetComponent<CharacterController>().SimpleMove(transform.forward * vertical * m_speed);
    }

    //通过CharacterController组件 键盘移动物体 Move控制移动
    public void PlayerMove_KeyCharacterController2()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下
        float moveY = 0;
        float m_gravity = 10f;
        moveY -= m_gravity * Time.deltaTime;//重力
        Player.GetComponent<CharacterController>().Move(new Vector3(horizontal, moveY, vertical) * m_speed * Time.deltaTime);
    }
}
