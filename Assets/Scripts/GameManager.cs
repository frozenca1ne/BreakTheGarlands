using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("EnemySettings")]
    [SerializeField]
    private GameObject[] enemys;

    [Header("CreateSettings")]
    [SerializeField] private Transform[] createPoints;
    [SerializeField] private float createTime = 1f;
    [SerializeField] private float changeCreateTimeRate = 0.9f;
    [SerializeField] private float changeCreateTimeDelay = 10f;

    [Header("PickUp")]
    [SerializeField] private GameObject[] pickUps;
    [SerializeField] private int pickUpCoeff = 3;
    [SerializeField] private float pickUpCreateTime = 5f;

    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
        StartCoroutine(nameof(CreateEnemys));
        StartCoroutine(ChangeCreateTime(changeCreateTimeRate, changeCreateTimeDelay));
        StartCoroutine(CreatePickUp(pickUpCreateTime));
    }
   
    private IEnumerator CreateEnemys()
    {
        while(_isAlive)
        {
            var enemyIndex = Random.Range(0, enemys.Length - 1);
            var positionIndex = Random.Range(0, createPoints.Length - 1);
            yield return new WaitForSeconds(createTime);
            Instantiate(enemys[enemyIndex], createPoints[positionIndex].transform.position, Quaternion.identity);

        }
    }
    private IEnumerator ChangeCreateTime(float rate,float delay)
    {
        yield return new WaitForSeconds(delay); 
        while(_isAlive)
        {
            createTime *= rate;
            yield return new WaitForSeconds(delay);
        }
    }
    private IEnumerator CreatePickUp(float rate)
    {        
        while (_isAlive)
        {
            var createChance = Random.Range(0, 10);
            var pickUpIndex = Random.Range(0, pickUps.Length - 1);
            var positionIndex = Random.Range(0, createPoints.Length - 1);
            yield return new WaitForSeconds(rate);
            if(createChance<pickUpCoeff)
            {
                Instantiate(pickUps[pickUpIndex], createPoints[positionIndex].transform.position, Quaternion.identity);
            }
        }
    }

}
