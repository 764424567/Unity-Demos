using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public Camera fpsCam;

    [Header("枪械状态")]
    [Tooltip("是否正在射击")]
    bool shooting;
    [Tooltip("是否可以射击")]
    bool readyToShoot;
    [Tooltip("是否在换弹")]
    bool reloading;

    [Header("弹夹")]
    [Tooltip("弹夹容量")]
    public int magazineSize;
    [Tooltip("当前弹夹容量")]
    public int bulletsLeft;
    [Tooltip("储备弹药容量")]
    public int reservedAmmoCapacity = 300;
    [Tooltip("当前剩余射击发射的子弹数")]
    public int bulletsShot;

    [Header("射击")]
    [Tooltip("射击间隔时间")]
    public float timeBetweenShooting;
    [Tooltip("射击时的散布度")]
    public float spread;
    [Tooltip("射击的最大距离")]
    public float range;
    [Tooltip("每次射击发射的子弹数")]
    public int bulletsPerTap;
    [Tooltip("是否允许按住射击")]
    public bool allowButtonHold;
    [Tooltip("每次射击造成的伤害")]
    public int damage;  // 伤害
    [Tooltip("装填弹药的时间")]
    public float reloadTime;
    [Tooltip("连发射击之间的间隔时间")]
    public float timeBetweenShots;
    [Tooltip("后坐力")]
    public float recouilForce;

    [Tooltip("动画")]
    private Animator animator;

    public GameObject muzzleFlash; // 枪口火焰/火光


    [Tooltip("弹孔")]
    public GameObject bulletHoleGraphic;

    [Header("子弹")]
    [Tooltip("子弹预制体")]
    public GameObject bulletPrefab;
    [Tooltip("子弹发射点")]
    public GameObject BulletShootPoint;
    [Tooltip("子弹速度")]
    public float bulletForce;

    [Tooltip("开枪音效")]
    public AudioClip fireClip;
    [Tooltip("换弹音效")]
    public AudioClip reloadClip;

    private void Awake()
    {
        bulletsLeft = magazineSize;//赋值当前弹夹容量
        readyToShoot = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        // 是否允许按住射击
        if (allowButtonHold)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        // 射击
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

        //换弹
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
            Reload();
    }

    private void Shoot()
    {
        //将开火名称转换为哈希
        int fire = Animator.StringToHash("Fire");
        //播放开火动画
        animator.SetTrigger(fire);
        // 射击状态
        readyToShoot = false;
        transform.localPosition -= Vector3.forward * recouilForce; // 后坐力使枪支向后移动
        // 散布
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        // 计算带有散布的射击方向
        Vector3 direction = fpsCam.transform.forward + fpsCam.transform.TransformDirection(new Vector3(x, y, 0));
        // 射线检测
        if (Physics.Raycast(fpsCam.transform.position, direction, out RaycastHit rayHit, range))
        {
            muzzleFlash.SetActive(true);//枪口火焰/火光  
            Invoke("UnEffect", 0.1f);//0.2秒关闭
            if (rayHit.collider.CompareTag("Enemy"))
            {
                //场景显示红线，方便调试查看
                Debug.DrawLine(fpsCam.transform.position, rayHit.point, Color.red, 10f);
                Debug.Log("击中敌人");
                //使用 LookRotation() 方法来让子弹孔特效朝向被击中表面的法线方向。其中 rayHit.normal 是表示被击中表面法线方向的向量
                var res = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                res.transform.parent = rayHit.transform;//设置父类
            }
            else
            {
                //场景显示红线，方便调试查看
                Debug.DrawLine(fpsCam.transform.position, rayHit.point, Color.blue, 10f);
                Debug.Log("击中其他对象");
                //使用 LookRotation() 方法来让子弹孔特效朝向被击中表面的法线方向。其中 rayHit.normal 是表示被击中表面法线方向的向量
                var res = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                res.transform.parent = rayHit.transform;//设置父类
            }
        }

        //实例化一个子弹
        GameObject bullet = Instantiate(bulletPrefab, BulletShootPoint.transform.position, BulletShootPoint.transform.rotation);
        //给子弹拖尾一个向前的速度力（加上射线打出去的偏移值）
        bullet.GetComponent<Rigidbody>().velocity = (BulletShootPoint.transform.forward + direction) * bulletForce;

        bulletsLeft--;
        bulletsShot--;

        // 射击时间恢复
        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    /// <summary>
    /// 取消特效
    /// </summary>
    private void UnEffect()
    {
        muzzleFlash.SetActive(false);
    }

    // 射击时间恢复
    private void ResetShot()
    {
        readyToShoot = true;
    }

    // 换弹
    public void Reload()
    {
        int reload = Animator.StringToHash("Reload");
        animator.SetTrigger(reload);
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    // 换弹
    private void ReloadFinished()
    {
        if (reservedAmmoCapacity <= 0) return;

        //计算需要填装的子弹数=1个弹匣子弹数-当前弹匣子弹数
        int bullectToLoad = magazineSize - bulletsLeft;

        //计算备弹需扣除子弹数
        int bullectToReduce = (reservedAmmoCapacity >= bullectToLoad) ? bullectToLoad : reservedAmmoCapacity;

        reservedAmmoCapacity -= bullectToReduce;//减少备弹数

        bulletsLeft += bullectToReduce;//当前子弹数增加
        bulletsLeft = magazineSize;
        reloading = false;
    }
}