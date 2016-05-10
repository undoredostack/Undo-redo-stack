namespace Ailleron.UndoRedoStack
{
    public class Command3 : ICommand
    {
        private IReceiver _receiver;

        public Command3(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            var context = new ActionContext();
            context.CommandName = this.GetType().Name.ToString();
            context.ActionType = ActionType.Execute;

            _receiver.Action(context);
        }

        public void Revert()
        {
            var context = new ActionContext();
            context.CommandName = this.GetType().Name.ToString();
            context.ActionType = ActionType.Revert;

            _receiver.Action(context);
        }
    }
}
