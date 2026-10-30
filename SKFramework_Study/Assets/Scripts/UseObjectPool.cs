using SK.Framework;
using SK.Framework.ObjectPool;
using UnityEngine;

public class UseObjectPool : MonoBehaviour
{
    //×Óµ¯Ô¤ÖÆÌå
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        SKFramework.Module<ObjectPool>().CreateBy(() =>
        {
            var instance = Instantiate(bulletPrefab);
            instance.transform.SetParent(transform);
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = Quaternion.identity;
            instance.SetActive(true);
            Bullet bullet = instance.GetComponent<Bullet>();
            return bullet;
        });
    }
}