namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.CombatSystem.PartyComposers;
    using ProjectEON.PartySystem;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Units;
    using UnityEngine.EventSystems;

    public class TargetManager : MonoBehaviour
    {
        private UnitCard _selectedCard;
        private Unit _selectedTargetUnit;

        public void SelectCard(UnitCard selectedCard)
        {
            if(_selectedCard)
                _selectedCard.Deselect();

            _selectedCard = selectedCard;
        }


        private void Update()
        {
            if (_selectedCard)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (EventSystem.current.IsPointerOverGameObject()) // There is no need to check what is clicking in the 3d world anymore 
                    {                                                  // because the UnitCard knows when the pointer is clicking on it.
                        return;                                        // Otherwise it will instantly deselect the card 'cause the raycast won't hit a UI gameobject.
                    }

                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.transform.name);

                        if (_selectedCard)
                        {
                            if (hit.transform.TryGetComponent(out Unit unit))
                            {
                                SelectTargetUnit(unit);
                                unit.TakeDamage(_selectedCard.Data.Power); // To change with attacks manager.
                                Destroy(_selectedCard.gameObject);
                            }
                            else
                            {
                                SelectCard(null);
                            }
                        }
                    }
                }
            }
        }

        private void SelectTargetUnit(Unit selectedTargetUnit)
        {
            _selectedTargetUnit = selectedTargetUnit;
        }
    }
}