using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class TestKV1 : MonoBehaviour
{
    private decimal Omega;// omega= 2¦Ðf
    private decimal vim;
    private decimal f;
    private decimal wi;
    private decimal r1;
    private decimal c1;
    private decimal l1;
    public decimal u0;//vom cos(omega l1/)
    private decimal vom;
    private decimal kv;
    private decimal psi;//psi=-arcty(omeag r1 c1 -r1/omeag l1)
    public float time;
    private LineChart chart;
    public GameObject LineObj;

    void Awake()
    {
        chart = LineObj.GetComponent<LineChart>();
        if (chart != null)
        {
            GameObject.DestroyImmediate(chart);
        }
        chart = LineObj.AddComponent<LineChart>();
        chart.title.show = true;
        chart.title.text = "Sin Curve";

        chart.tooltip.show = true;
        chart.legend.show = false;

        chart.xAxises[0].show = true;
        chart.xAxises[1].show = false;
        chart.yAxises[0].show = true;
        chart.yAxises[1].show = false;

        chart.xAxises[0].type = Axis.AxisType.Value;
        chart.yAxises[0].type = Axis.AxisType.Value;

        chart.xAxises[0].boundaryGap = false;
        chart.xAxises[0].maxCache = 0;
        chart.series.list[0].maxCache = 0;

        chart.RemoveData();

        var serie = chart.AddSerie(SerieType.Line);
        serie.symbol.type = SerieSymbolType.None;
        serie.lineType = LineType.Normal;
    }

    void Start()
    {
        vim = 6;
        f = 5000;
        wi = 0;
        r1 = 620;
        l1 = 0.001m;
        c1 = 0.000001m;
        Omega = 2 * (decimal)Mathf.PI * f;
        Debug.Log(Omega);
        psi = (decimal)-Mathf.Atan((float)(Omega * r1 * c1 - (r1 / (Omega * l1))));
        Debug.Log(psi);
        kv = (Omega * l1) / (decimal)Mathf.Sqrt((float)
                ((decimal)Mathf.Pow((float)(r1 - (decimal)Mathf.Pow((float)Omega, 2) * r1 * l1 * c1), 2)
                +
                (decimal)Mathf.Pow((float)(Omega * l1), 2))
                );
        Debug.Log(kv);
        vom = kv * vim;
        Debug.Log(vom);
    }

    private void Update()
    {
        TimeEvent();
    }

    private void TimeEvent()
    {
        time += 1;
        u0 = vom * (decimal)Mathf.Cos((float)(Omega * (decimal)time + wi + psi));

        DrawLine((float)time, (float)u0);
    }

    private void DrawLine(float time,float sinValue)
    {
        chart.AddData(0, time, sinValue);
    }
}
