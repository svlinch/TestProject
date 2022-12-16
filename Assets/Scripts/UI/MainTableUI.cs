using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainTableUI : SingletonStarter<MainTableUI>
{
    [SerializeField]
    private Button _endTurnButton;

    public override IEnumerator Initialize()
    {
        _endTurnButton.onClick.AddListener(endTurnHandle);
        yield return null;
    }

    public void SetButtonState(bool state)
    {
        _endTurnButton.interactable = state;
    }

    private void endTurnHandle()
    {
        BattleController.Instance.EndTurnHandle(true);
    }
}
