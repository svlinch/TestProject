public class ActionController
{
    public void CheckoutAction(AbilityIcon ability, SimpleUnit unit)
    {
        //animation, etc
        var skillModel = GameData.Instance.GetSkillModel(ability.GetId());
        ability.Reset();
        unit.ApplySkill(skillModel);
    }
}