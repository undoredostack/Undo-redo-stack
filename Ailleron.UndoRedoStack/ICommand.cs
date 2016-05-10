namespace Ailleron.UndoRedoStack
{
    public interface ICommand
    {
        void Execute();
        void Revert();
    }
}
