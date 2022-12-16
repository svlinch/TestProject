using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private EventSystem _eventSystem;
    private PointerEventData _pointerEventData;
    [SerializeField]
    private PointerController _pointer;

    public bool WaitForInput = true;

    private bool _dragging;
    private AbilityIcon _currentDraggingAbility;

    public void Awake()
    {
        _pointerEventData = new PointerEventData(_eventSystem);
        Events.RestartGame += restartHandle;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Events.RestartGame.Invoke();
            return;
        }

        if (!WaitForInput)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BattleController.Instance.EndTurnHandle(true);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            checkoutMouseDown();
            return;
        }

        if (!_dragging)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            checkoutMouseMove();
        }

        if (Input.GetMouseButtonUp(0))
        {
            checkoutMouseUp();
        }
    }

    private void checkoutMouseDown()
    {
        _pointerEventData.position = Input.mousePosition;

        var raycasts = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_pointerEventData, raycasts);
        if (raycasts.Count > 0)
        {
            var success = false;
            var result = getResultWithTag(raycasts, "Ability", out success);
            if (success)
            {
                startDrag(result);
            }
        }
    }

    private void checkoutMouseMove()
    {
        _pointer.UpdateDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void checkoutMouseUp()
    {
        _pointerEventData.position = Input.mousePosition;

        var raycasts = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_pointerEventData, raycasts);
        var targetSelf = _currentDraggingAbility.GetTargetInfo();

        if (raycasts.Count > 0)
        {
            var success = false;
            RaycastResult result;
            if (targetSelf)
            {
                result = getResultWithTag(raycasts, "Player", out success);
                //can use "self" abilities for allies, without this check
                if (success)
                {
                    success = result.gameObject.GetComponent<SimpleUnit>() == _currentDraggingAbility.GetUnit();
                }
            }
            else
            {
                result = getResultWithTag(raycasts, "Enemy", out success);
            }

            if (success)
            {
                BattleController.Instance.ApplySkillToUnit(_currentDraggingAbility, result.gameObject.GetComponent<SimpleUnit>());
                _currentDraggingAbility = null;
            }
        }

        _pointer.Reset();
        _dragging = false;
    }

    private void startDrag(RaycastResult ability)
    {
        _dragging = true;

        _currentDraggingAbility = ability.gameObject.GetComponent<AbilityIcon>();
        _pointer.StartDrag(_currentDraggingAbility.transform.position);
    }

    private RaycastResult getResultWithTag(List<RaycastResult> raycasts, string tag, out bool success)
    {
        foreach (var result in raycasts)
        {
            if (result.gameObject.tag.Equals(tag))
            {
                success = true;
                return result;
            }
        }
        success = false;
        return raycasts[0];
    }

    private void restartHandle()
    {
        if (_dragging)
        {
            _pointer.Reset();
            _dragging = false;
        }
    }
}