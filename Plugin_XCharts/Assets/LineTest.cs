using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class LineTest : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        var chart = gameObject.GetComponent<LineChart>();
        //if (chart == null)
        //{
        //    chart = gameObject.AddComponent<LineChart>();
        //    chart.SetSize(580, 300);//代码动态添加图表需要设置尺寸，或直接操作chart.rectTransform
        //}
        chart.title.show = true;
        chart.title.text = "曲线图";
        chart.tooltip.show = true;
        chart.legend.show = false;
        chart.tooltip.titleFormatter = " ";
        chart.xAxises[0].show = true;
        chart.xAxises[0].type = Axis.AxisType.Category;
        chart.xAxises[0].splitNumber = 11;
        chart.xAxises[0].boundaryGap = false;
        chart.xAxises[1].show = false;
        chart.yAxises[0].type = Axis.AxisType.Value;
        chart.yAxises[0].show = true;
        chart.yAxises[0].splitNumber = 10;
        chart.yAxises[0].interval = 10;
        chart.yAxises[1].show = false;
        chart.RemoveData();
        chart.AddSerie(SerieType.Line);
        chart.series.list[0].name = "角度";
        chart.series.list[0].lineType = LineType.Smooth;
        SerieSymbol sy = new SerieSymbol();
        sy.show = true;
        sy.type = SerieSymbolType.Circle;
        sy.gap = 2;
        sy.sizeType = SerieSymbolSizeType.Custom;
        sy.size = 7;
        chart.series.list[0].symbol = sy;
        LineStyle ls = new LineStyle();
        ls.show = true;
        ls.type = LineStyle.Type.Solid;
        ls.toColor = new Color32(18, 240, 111, 255);
        ls.toColor2 = new Color32(244, 29, 140, 255);
        ls.width = 2.5f;
        chart.series.list[0].lineStyle = ls;
        SerieLabel sl = new SerieLabel();
        sl.show = true;
        sl.position = SerieLabel.Position.Outside;
        sl.offset = new Vector3(0, 20, 0);
        sl.fontSize = 25;
        chart.series.list[0].label = sl;
        SerieAnimation sa = new SerieAnimation();
        sa.enable = true;
        chart.series.list[0].animation = sa;
        for (int i = 0; i <= 10; i++)
        {
            chart.AddXAxisData(i.ToString());
            //chart.AddData(0, Random.Range(10, 20));
        }
        //for (int i = 0; i < 10; i++)
        //{
        //    chart.AddYAxisData(i.ToString());
        //    chart.AddData(0, Random.Range(20, 30));
        //}
        chart.AddData(0, 180);
        chart.AddData(0, 180);
        chart.AddData(0, 132);
        chart.AddData(0, 126);
        chart.AddData(0, 124);
        chart.AddData(0, 114);
        chart.AddData(0, 95);
        chart.AddData(0, 88.5f);
        chart.AddData(0, 82);
        chart.AddData(0, 80);
        chart.AddData(0, 73.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
