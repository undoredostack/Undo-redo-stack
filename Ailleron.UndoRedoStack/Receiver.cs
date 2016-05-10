namespace Ailleron.UndoRedoStack
{
    public class Receiver : IReceiver
    {
        private string _message;

        public string ActionResultMessage
        {
            get { return _message; }
        }

        public void Action(ActionContext context)
        {
            var action = new ActionResult();
            action.ExecuteResult(context);
            _message = action.Result;
        }
    }
}
