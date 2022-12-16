using System.Collections.Generic;
using UnityEngine;

public class TurnController: MonoBehaviour
{
    [SerializeField]
    private InputController _inputController;
    private EnemyTurnController _enemyTurnController;

    public bool PlayerTurn
    {
        get;
        private set;
    }

    public void Initialize()
    {
        _enemyTurnController = new EnemyTurnController();
    }

    public void ResetGame()
    {
        if (!PlayerTurn)
        {
            StopCoroutine(_enemyTurnController.Coroutine);
        }

        PlayerTurn = false;
        _inputController.WaitForInput = false;
    }

    public void SetTurn(bool playerTurn, List<SimpleUnit> playerUnits, List<SimpleUnit> enemyUnits)
    {
        Pool.Instance.ResetAbilities();

        if (!playerTurn)
        {
            startEnemyTurn(playerUnits, enemyUnits);
        }
        else
        {
            startPlayerTurn(playerUnits, enemyUnits);
        }
    }

    private void startPlayerTurn(List<SimpleUnit> playerUnits, List<SimpleUnit> enemyUnits)
    {
        foreach (var unit in playerUnits)
        {
            unit.GetRandomAbility();
            unit.CheckoutEffects();
        }

        UnitOperations.CheckForDeadUnits(playerUnits);
        UnitOperations.CheckForEndGame(playerUnits, enemyUnits);

        PlayerTurn = true;
        MainTableUI.Instance.SetButtonState(true);
        _inputController.WaitForInput = true;
    }

    private void startEnemyTurn(List<SimpleUnit> playerUnits, List<SimpleUnit> enemyUnits)
    {
        foreach (var unit in enemyUnits)
        {
            unit.GetRandomAbility();
            unit.CheckoutEffects();
        }

        UnitOperations.CheckForDeadUnits(enemyUnits);
        UnitOperations.CheckForEndGame(playerUnits, enemyUnits);

        _enemyTurnController.Setup(playerUnits, enemyUnits);
        StartCoroutine(_enemyTurnController.Coroutine);

        PlayerTurn = false;
        MainTableUI.Instance.SetButtonState(false);
        _inputController.WaitForInput = false;
    }
}