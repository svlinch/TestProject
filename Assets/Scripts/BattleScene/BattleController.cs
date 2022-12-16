using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : SingletonStarter<BattleController>
{
    [SerializeField]
    private LevelController _levelController;
    [SerializeField]
    private TurnController _turnController;

    private ActionController _actionController;

    private List<SimpleUnit> _playerUnits;
    private List<SimpleUnit> _enemyUnits;

    public override IEnumerator Initialize()
    {
        Events.RestartGame += restartGameHandle;
        Events.UnitIsDead += killedUnitHandle;

        _actionController = new ActionController();

        _turnController.Initialize();
        yield return StartCoroutine(generateLevel());
    }

    public void EndTurnHandle(bool Player)
    {
        _turnController.SetTurn(!Player, _playerUnits, _enemyUnits);
    }

    public void ApplySkillToUnit(AbilityIcon ability, SimpleUnit unit)
    {
        _actionController.CheckoutAction(ability, unit);
    }

    private IEnumerator generateLevel()
    {
        _playerUnits = new List<SimpleUnit>();
        _enemyUnits = new List<SimpleUnit>();
        yield return StartCoroutine(_levelController.GenerateLevel(_playerUnits, _enemyUnits));
        _turnController.SetTurn(true, _playerUnits, _enemyUnits);
    }

    private void killedUnitHandle(bool player)
    {
        UnitOperations.CheckForDeadUnits(player ? _playerUnits : _enemyUnits);
        UnitOperations.CheckForEndGame(_playerUnits, _enemyUnits);
    }

    private void restartGameHandle()
    {
        _turnController.ResetGame();

        MainTableUI.Instance.SetButtonState(false);
        StartCoroutine(generateLevel());
    }
}