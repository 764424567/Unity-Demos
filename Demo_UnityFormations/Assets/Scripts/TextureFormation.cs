using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 图形编队
/// </summary>
public class TextureFormation : MonoBehaviour
{
    /// <summary>
    /// 采样梯度，梯度越小，进度越高
    /// </summary>
    public int samplingStep = 5;
    /// <summary>
    /// 坐标缩放
    /// </summary>
    public float scale = 1f;
    /// <summary>
    /// 要采样的图片纹理
    /// </summary>
    public Texture2D texture;

    private List<Vector3> posList = new List<Vector3>();

    protected Transform trans;
    

    public void Awake()
    {
        trans = transform;
    }

    /// <summary>
    /// 计算点阵
    /// </summary>
    private void CalculatePoints()
    {
        if(Application.isPlaying)
        {
            if (0 != posList.Count)
                return;
        }
        else
        {
            posList.Clear();
        }
        
        var widthStep = texture.width / samplingStep;
        var heightStep = texture.height / samplingStep;
        for (int i = 0; i <= heightStep; i += samplingStep)
        {
            for (int j = 0; j <= widthStep; j += samplingStep)
            {
                // 一个block
                int colorPixelCnt = 0;
                for (int ii = 0; ii <= samplingStep; ++ii)
                {
                    for (int jj = 0; jj <= samplingStep; ++jj)
                    {
                        var color = texture.GetPixel(j * samplingStep + jj, i * samplingStep + ii);
                        if (color.r + color.g + color.b > 1f)
                        {
                            ++colorPixelCnt;
                        }
                    }
                }
                // 有颜色的像素超数量过了方块的边长
                if (colorPixelCnt > samplingStep)
                {
                    var pos = new Vector3(-texture.width / 2 + j * samplingStep + samplingStep / 2f, 0, -texture.height / 2 + i * samplingStep + samplingStep / 2f);
                    // 对坐标进行缩放
                    pos *= scale;
                    posList.Add(pos);
                }
            }
        }
    }

    /// <summary>
    /// 获取点阵数据
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Vector3> EvaluatePoints()
    {
        CalculatePoints();
        var rootPos = Vector3.zero;
        if (null != trans)
            rootPos = trans.position;
        for (int i = 0; i < posList.Count; ++i)
        {
            yield return rootPos + posList[i];
        }
    }

    public void ReCalculate()
    {
        posList.Clear();
    }
}
