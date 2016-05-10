namespace Ailleron.UndoRedoStack
{
    public interface IReceiver
    {
        string ActionResultMessage { get; }
        void Action(ActionContext context);
    }
}
