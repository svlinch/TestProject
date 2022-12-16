using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController: MonoBehaviour
{
    [SerializeField]
    private Transform _playerHolder;
    [SerializeField]
    private Transform _enemyHolder;

    public IEnumerator GenerateLevel(List<SimpleUnit> playerUnits, List<SimpleUnit> enemyUnits)
    {
        var enemiesCount = GameData.Instance.GetRules(false);

        for (int i = 0; i < enemiesCount; i++)
        {
            var newEnemy = Pool.Instance.GetEnemyUnit();
            newEnemy.transform.SetParent(_enemyHolder);

            var enemyModel = GameData.Instance.GetUnitModel(1);
            newEnemy.Initialize(enemyModel);

            enemyUnits.Add(newEnemy);
            yield return null;
        }

        var playersCount = GameData.Instance.GetRules(true);

        for (int i = 0; i < playersCount; i++)
        {
            var newPlayer = Pool.Instance.GetPlayerUnit();
            newPlayer.transform.SetParent(_playerHolder);

            var playerModel = GameData.Instance.GetUnitModel(0);
            newPlayer.Initialize(playerModel);

            playerUnits.Add(newPlayer);
            yield return null;
        }
        yield return null;
    }
}