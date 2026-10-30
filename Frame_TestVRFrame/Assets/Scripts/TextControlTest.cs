using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControlTest : MonoBehaviour
{
    public Text m_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_Text.text = "通过虚拟仿真平台技术支持，模拟异位妊娠临医结合诊疗过程，以临床收集到的真实病例为依托，使学生模拟异位妊娠患者诊治过程，通过问诊、查体、辅助检查、中医舌脉诊来收集病史资料，对收集的资料进行分析、归";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Text.text = "辅助检查、中医舌脉诊来收病史资料，对收集的资料进行分析、归纳、总结，对患者疾病及病证进行诊断及";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_Text.text = "对收集的资料进行分析、归纳、总结，对患者疾病及鉴别诊断，制定适宜的治疗原则及治疗方法，并对疾病进行预防指导。其整个流程重现临床诊疗过程，尽可能接近";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Text.text = "尽可能接近临床，使学生掌握疾病诊断与治疗的同时，使学生掌握疾病诊断与治疗的同时，培养其临床辨证思维能力。";
        }
    }
}
