using UnityEngine;

public class ArrowShoot1 : MonoBehaviour
{
    [SerializeField] private Transform _arrowSpawnPosition;
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private GameObject _handArrow;

    private float _range = 10000f;


    void Shoot()
    {
        _handArrow.SetActive(false);

        Vector2 ScreenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, _range))
        {
            Arrow arrow = Instantiate(_arrowPrefab, _arrowSpawnPosition.transform.position, _arrowSpawnPosition.transform.rotation);
            arrow.SetTarget(hit.point);
            Destroy(arrow, 3);
        }
    }
}