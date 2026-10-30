using UnityEngine;
using SK.Framework;
using SK.Framework.ObjectPool;

public class Bullet : MonoBehaviour, IPoolable
{
    public bool isRecycled { get; set; }

    public void OnRecycled()
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}