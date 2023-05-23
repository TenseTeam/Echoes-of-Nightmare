namespace ProjectEON.UI.Inventory
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIInventoryDescription : MonoBehaviour
    {
        [SerializeField] 
        private Image _itemImage;
        [SerializeField] 
        private TextMeshProUGUI _title;
        [SerializeField] 
        private TextMeshProUGUI _type;
        [SerializeField] 
        private TextMeshProUGUI _owner;
        [SerializeField] 
        private TextMeshProUGUI _description;

        private void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            _itemImage.gameObject.SetActive(false);
            _title.text = "";
            _type.text = "";
            _owner.text = "";
            _description.text = "";
        }

        public void SetDescription(Sprite sprite, string itemTitle, string itemType, string itemOwner, string itemDescription)
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = sprite;
            _title.text = itemTitle;
            _type.text = itemType;
            _owner.text = itemOwner;
            _description.text = itemDescription;
        }
    }
}
