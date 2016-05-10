using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ailleron.UndoRedoStack.Tests
{
    [TestClass()]
    public class CommandTests
    {
        private IReceiver _receiver;
        private ICommand _command1;

        [TestInitialize()]
        public void Initialize()
        {
            _receiver = new Receiver();
            _command1 = new Command1(_receiver);
        }

        [TestMethod()]
        public void TestRevert()
        {
            _command1.Execute();
            _command1.Revert();

            Assert.AreEqual("Command1.Revert", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestExecute()
        {
            _command1.Execute();

            Assert.AreEqual("Command1.Execute", _receiver.ActionResultMessage);
        }
    }
}
