using ProjectEON.Player.InteractionSystem;
namespace ProjectEON.GenericInterfaces
{
    public interface IPlayer { }
    public interface IInteractable
    {
        void Interact(InteractionComponent interaction);
    }
}