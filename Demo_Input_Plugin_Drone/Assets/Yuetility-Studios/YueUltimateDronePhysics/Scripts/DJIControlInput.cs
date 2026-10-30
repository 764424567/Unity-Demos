using Rewired;
using UnityEngine;

namespace YueUltimateDronePhysics
{
    public class DJIControlInput : MonoBehaviour
    {
        [Header("这个组件注入到InputModule中，并使用来自DJI 控制器的输入\n")]

        [SerializeField]
        private YueDronePhysics dronePhysics;
        [SerializeField]
        private YueInputModule inputModule;

        private Vector3 startPos = Vector3.zero;
        private Quaternion startRot;

        private Player player; // Rewired Player

        private void Awake()
        {
            // 获取该玩家的Rewired Player对象
            player = ReInput.players.GetPlayer(0);
        }

        void Start()
        {
            dronePhysics = GetComponent<YueDronePhysics>();
            inputModule = GetComponent<YueInputModule>();

            startPos = transform.position;
            startRot = transform.rotation;
        }

        void Update()
        {
            inputModule.rawLeftHorizontal = player.GetAxis("LeftHorizontal");
            inputModule.rawLeftVertical = player.GetAxis("LeftVertical");

            inputModule.rawRightHorizontal = player.GetAxis("RightHorizontal");
            inputModule.rawRightVertical = player.GetAxis("RightVertical");

            if (player.GetButton("R"))
            {
                //Reset Position & Rotation on Respawn
                transform.position = startPos;
                transform.rotation = startRot;

                // Reset Rigidbody on Respawn
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                // Reset Target Rotation on Respawn
                GetComponent<YueDronePhysics>().ResetInternals();
            }
        }
    }
}
