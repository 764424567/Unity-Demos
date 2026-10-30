using DG.Tweening;
using UnityEngine;
public class FirstManager : MonoBehaviour
{
    public static FirstManager Instance;
    public First[] _first;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        for (int i = 0; i < _first.Length; i++)
        {
            _first[i].isShanShow = false;
        }

        // FirstMove(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    int index;
    public void FirstMove(int idx)
    {
        index = idx;
        _first[idx].isShanShow = true;
        index++;
        Invoke("CloseFirst", 4f);
    }
    public void CloseFirst()
    {
        if (index >= _first.Length)
        {
            // print("最后一个");
            _first[index - 1].isShanShow = false;
            _first[index - 1].GetComponent<Transform>().DOLocalMove(new Vector2(0, 0), 3f);
            _first[index - 1].GetComponent<Transform>().DOScale(new Vector3(6, 6, 6), 3f);
        }
        else
        {
            _first[index - 1].isShanShow = false;
            FirstMove(index);
        }

    }
    public void ChongXing()
    {
        CancelInvoke();
        for (int i = 0; i < _first.Length; i++)
        {
            _first[i].isShanShow = false;
        }
        index = 0;
        _first[4].GetComponent<Transform>().DOLocalMove(new Vector2(602, 242), 0.1f);
        _first[4].GetComponent<Transform>().DOScale(new Vector3(1, 1, 1), 0.1f);
        FirstMove(0);
    }
}