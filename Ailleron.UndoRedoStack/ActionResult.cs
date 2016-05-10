using System;

namespace Ailleron.UndoRedoStack
{
    public class ActionResult : IActionResult
    {
        private string _result;

        public string Result
        {
            get { return _result; }
        }

        public void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var commandName = context.CommandName;
            var actionType = Enum.GetName(typeof(ActionType), context.ActionType);

            _result = string.Format("{0}.{1}", commandName, actionType);
        }
    }
}
