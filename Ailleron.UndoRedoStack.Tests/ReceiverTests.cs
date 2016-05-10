using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ailleron.UndoRedoStack.Tests
{
    [TestClass()]
    public class ReceiverTests
    {
        private IReceiver _receiver;

        [TestInitialize()]
        public void Initialize()
        {
            _receiver = new Receiver();
        }

        [TestMethod()]
        public void TestExecute()
        {
            var context = new ActionContext();
            context.CommandName = "Command1";
            context.ActionType = ActionType.Execute;

            _receiver.Action(context);

            Assert.AreEqual("Command1.Execute", _receiver.ActionResultMessage);
        }
    }
}
