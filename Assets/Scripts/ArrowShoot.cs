using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    [SerializeField] private Transform _arrowSpawnPosition;
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private Transform _handArrow;

    private int _destroyTime = 3;
    private float _range = 10000f;
    private float _screenCenterValue = 2f;


    private void Shoot()
    {
        _handArrow.gameObject.SetActive(false);

        Vector2 ScreenCenter = new Vector2(Screen.width / _screenCenterValue, Screen.height / _screenCenterValue);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, _range))
        {
            Arrow arrow = Instantiate(_arrowPrefab, _arrowSpawnPosition.transform.position, _arrowSpawnPosition.transform.rotation);
            arrow.SetTarget(hit.point);
            Destroy(arrow, _destroyTime);            
        }        
    }    
}