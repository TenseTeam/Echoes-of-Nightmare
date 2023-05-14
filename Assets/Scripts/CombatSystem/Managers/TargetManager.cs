namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData.Enums;

    public class TargetManager : MonoBehaviour
    {
        private UnitCard _selectedCard;
        private Unit _selectedTargetUnit;

        public void SelectCard(UnitCard selectedCard)
        {
            if(_selectedCard && _selectedCard != selectedCard)
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
                        if (_selectedCard)
                        {
                            if (hit.transform.TryGetComponent(out Unit targetedUnit))
                            {
                                //SelectTargetUnit(targetedUnit);

                                // All this to change with attacks manager methods.
                                _selectedCard.Dispose();
                                targetedUnit.TakeDamage(_selectedCard.Data.Power);
                                _selectedCard.RelatedHand.RelatedUnit.UnitTurns.NextState();
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

        //private bool TrySelectTargetUnit(UnitCard card, out Unit selectedTargetUnit)
        //{
            
        //}
    }
}