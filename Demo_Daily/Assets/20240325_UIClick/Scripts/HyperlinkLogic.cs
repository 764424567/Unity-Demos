using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIClick
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class HyperlinkLogic : MonoBehaviour
    {
        public HyperlinkText[] hyperlinkText;

        public GameObject WeaponPanel;

        void Start()
        {
            // 绑定事件
            for (int i = 0; i < hyperlinkText.Length; i++)
            {
                hyperlinkText[i].onLinkClick = (info) => onclick(info);
            }
        }

        void onclick(string info)
        {
            Debug.Log(info);

            Vector3 pos = Input.mousePosition;
            pos.x += 100;
            pos.y -= 100;
            WeaponPanel.transform.position = pos;

            switch (info)
            {
                case "匕首":
                    WeaponItem.Instance.ShowInfo(0,info,"普通","这是一把绝世匕首。");
                    break;
                case "宝刀":
                    WeaponItem.Instance.ShowInfo(1, info, "史诗", "这是一把绝世宝刀。");
                    break;
                case "斧头":
                    WeaponItem.Instance.ShowInfo(2, info, "优秀", "这是一把绝世斧头。");
                    break;
            }
        }
    }
}