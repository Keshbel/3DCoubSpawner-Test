using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("Initialization")]
    public GameObject cubePrefab;
    public Transform cubeParent;
    private float _y = 0.5f; //floor y level

    [Header("RuntimeOptions")]
    public GameObject currentCube;

    [Space]
    public float timeToNewSpawn;
    public float speed = 2;
    public float x, z;

    private Coroutine _spawnRoutine;
    
    public void FullSpawnProcedure()
    {
        if (_spawnRoutine != null) StopSpawn();
        _spawnRoutine = StartCoroutine(FullSpawnProcedureRoutine());
    }

    public void StopSpawn()
    {
        StopCoroutine(_spawnRoutine);
    }

    private IEnumerator FullSpawnProcedureRoutine()
    {
        while (Application.isPlaying)
        {
            //если куб уже существует, уничтожить его
            if (currentCube) Destroy(currentCube);
            
            //спавним новый куб
            currentCube = Instantiate(cubePrefab, cubeParent);

            //расчёт дистанции
            var toPosition = new Vector3(x, _y, z);
            var distance = Vector3.Distance(currentCube.transform.position, toPosition);
            var movingTime = distance / speed;
            
            //движение
            currentCube.transform.DOMove(toPosition, movingTime).SetEase(Ease.Linear).OnComplete(()=> Destroy(currentCube));
            
            //ожидание спавна нового (включая время движения)
            yield return new WaitForSeconds(timeToNewSpawn+movingTime);
        }
    }
}
