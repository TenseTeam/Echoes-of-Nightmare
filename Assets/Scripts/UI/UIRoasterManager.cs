using ProjectEON.CombatSystem.Units;
using ProjectEON.Managers;
using ProjectEON.PartySystem;
using UnityEngine;

public class UIRoasterManager : MonoBehaviour
{
    [SerializeField]
    private UIRoasterTile _roasterPrefab;
    [SerializeField]
    private RectTransform _rosterPanel;
    [SerializeField]
    private PlayerParty _party;

    public void InitializeRoasterUI()
    {
        foreach (UnitManager unit in GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits())
        {
            if (Instantiate(_roasterPrefab, _rosterPanel).TryGetComponent(out UIRoasterTile uitile))
            {
                uitile.Init(unit.UnitData.UnitSprite, unit.Unit);//TO DO cambiare lo sprite con l'icona
            }           
        }
    }
}
