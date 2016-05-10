namespace Ailleron.UndoRedoStack
{
    public interface IActionResult
    {
        void ExecuteResult(ActionContext context);
    }
}
