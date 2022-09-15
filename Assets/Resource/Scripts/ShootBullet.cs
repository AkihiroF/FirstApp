using System.Collections;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject _bolletGameObject;

    [SerializeField] private Transform _objectFire;

    [Header("Parametrs")]
    [SerializeField] private float speedBillet;

    [SerializeField] private float speedFire;

    [SerializeField] private float timeLiveBullet;

    private Transform _playerBody;

    private bool onShoot = false;
    
    
    void Start()
    {
        _playerBody = _objectFire.parent;
        InputManager.FireBullet += FireBullet;
    }

    private void FireBullet()
    {
        if(onShoot) return;
        StartCoroutine(CreateBullet());
    }

    IEnumerator CreateBullet()
    {
        onShoot = true;
        Transform bullet = Instantiate(_bolletGameObject, _objectFire).transform;
        bullet.position = _objectFire.position;
        bullet.eulerAngles = _playerBody.eulerAngles;
        bullet.gameObject.SetActive(true);
        var controller = bullet.GetComponent<BulletController>();
        var _rb = bullet.GetComponent<Rigidbody>();
        _rb.AddForce(bullet.forward.normalized * speedBillet, ForceMode.Impulse);
        controller.ShootStart(timeLiveBullet);
        yield return new WaitForSeconds(speedFire);
        onShoot = false;
    }
}
