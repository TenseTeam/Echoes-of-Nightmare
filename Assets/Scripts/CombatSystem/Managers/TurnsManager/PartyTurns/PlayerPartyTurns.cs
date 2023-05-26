namespace ProjectEON.CombatSystem.StateMachines
{
    using Extension.Patterns.StateMachine;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;

    public class PlayerPartyTurns : PartyTurns<PlayerParty>
    {
        public override void InitStates(PlayerParty playerParty, TurnStateMachine parentStateMachine)
        {
            base.InitStates(playerParty, parentStateMachine);

            foreach (PlayerUnitManager unitManager in Party.GetComposedUnits())
            {
                States.Add(new PlayerPartyTurnState(unitManager.UnitData.UnitName, this, unitManager));
            }
            States.Add(new EndSubStateMachine("EndPlayerPartyPhase", this, parentStateMachine));
        }
    }
}