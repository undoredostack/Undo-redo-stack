namespace Ailleron.UndoRedoStack
{
    public class ActionContext
    {
        public string CommandName { get; set; }
        public ActionType ActionType { get; set; }
    }
}
