using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnController
{
    public IEnumerator Coroutine
    {
        get;
        private set;
    }

    public void Setup(List<SimpleUnit> players, List<SimpleUnit> enemies)
    {
        Coroutine = processTurn(players, enemies);
    }

    private IEnumerator processTurn(List<SimpleUnit> players, List<SimpleUnit> enemies)
    {
        yield return new WaitForSeconds(1f);
        foreach (var enemy in enemies)
        {
            var ability = (enemy as EnemyUnit).GetAbility();

            if (ability.GetTargetInfo())
            {
                BattleController.Instance.ApplySkillToUnit(ability, enemy);
            }
            else
            {
                var randomIndex = Random.Range(0, players.Count);
                BattleController.Instance.ApplySkillToUnit(ability, players[randomIndex]);
            }
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
        BattleController.Instance.EndTurnHandle(false);
    }
}