using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class TestKV : MonoBehaviour
{
    private float Omega;// omega= 2¦Ðf
    private float vim;
    private float f;
    private float wi;
    private float r1;
    private float c1;
    private float l1;
    public float u0;//vom cos(omega l1/)
    private float vom;
    private float kv;
    private float psi;//psi=-arcty(omeag r1 c1 -r1/omeag l1)
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
        l1 = 0.001f;
        c1 = 0.000001f;
        Omega = 2 * Mathf.PI * f;
        Debug.Log(Omega);
        psi = -Mathf.Atan(Omega * r1 * c1 - (r1 / (Omega * l1)));
        Debug.Log(psi);
        kv = (Omega * l1) / Mathf.Sqrt(
            Mathf.Pow(r1 - Mathf.Pow(Omega, 2) * r1 * l1 * c1, 2)
            +
            Mathf.Pow(Omega * l1, 2)
            );
        Debug.Log(kv);
        vom = kv * vim;
        Debug.Log(vom);

        Omega = 31416;
        psi = 0.25f;
        kv = 1;
        vom = 6;
    }

    private void Update()
    {
        TimeEvent();
    }

    //private void TimeEvent2()
    //{
    //    vim = 6;
    //    f = 5000;
    //    wi = 0;
    //    r1 = 620;
    //    l1 = 0.001m;
    //    c1 = 0.000001m;
    //    Debug.Log(c1);
    //    Omega = 2 * (decimal)Mathf.PI * f;
    //    Debug.Log(Omega);
    //    psi = (decimal)-Mathf.Atan((float)(Omega * r1 * c1 - (r1 / (Omega * l1))));
    //    Debug.Log(psi);
    //    kv = (Omega * l1) / (decimal)Mathf.Sqrt((float)
    //        ((decimal)Mathf.Pow((float)(r1 - (decimal)Mathf.Pow((float)Omega, 2) * r1 * l1 * c1), 2)
    //        +
    //        (decimal)Mathf.Pow((float)(Omega * l1), 2))
    //        );
    //    Debug.Log(kv);
    //    vom = kv * vim;
    //    Debug.Log(vom);
    //    Debug.Log(vom/vim);
    //    u0 = vom * (decimal)Mathf.Cos((float)(Omega + wi + psi));
    //    Debug.Log(u0);
    //}

    private void TimeEvent()
    {
        time += 1;
        if (time < 500)
        {
            u0 = vom * Mathf.Cos(Omega * time + wi + psi);

            DrawLine((float)time, (float)u0);
        }
    }

    private void DrawLine(float time,float sinValue)
    {
        chart.AddData(0, time, sinValue);
    }
}
