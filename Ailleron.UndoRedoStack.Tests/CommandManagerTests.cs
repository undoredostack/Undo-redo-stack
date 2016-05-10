using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ailleron.UndoRedoStack.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        private CommandManager _manager;
        private IReceiver _receiver;
        private ICommand _command1;
        private ICommand _command2;
        private ICommand _command3;

        [TestInitialize()]
        public void Initialize()
        {
            _manager = new CommandManager();
            _receiver = new Receiver();
            _command1 = new Command1(_receiver);
            _command2 = new Command2(_receiver);
            _command3 = new Command3(_receiver);
        }

        [TestMethod()]
        public void TestExecute1()
        {
            _manager.Execute(_command1);

            Assert.AreEqual(_command1, _manager.CurrentCommand);
            Assert.AreEqual("Command1.Execute", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestExecute2()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);

            Assert.AreEqual(_command2, _manager.CurrentCommand);
            Assert.AreEqual("Command2.Execute", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestUndo0()
        {
            _manager.Undo();

            Assert.IsNull(_manager.CurrentCommand);
            Assert.IsNull(_receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestUndo1()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();

            Assert.AreEqual(_command1, _manager.CurrentCommand);
            Assert.AreEqual("Command2.Revert", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestUndo2()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();
            _manager.Undo();

            Assert.IsNull(_manager.CurrentCommand);
            Assert.AreEqual("Command1.Revert", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestUndo3()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();
            _manager.Undo();
            _manager.Undo();

            Assert.IsNull(_manager.CurrentCommand);
            Assert.AreEqual("Command1.Revert", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestRedo0()
        {
            _manager.Redo();

            Assert.IsNull(_manager.CurrentCommand);
            Assert.IsNull(_receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestRedo1()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();
            _manager.Redo();

            Assert.AreEqual(_command2, _manager.CurrentCommand);
            Assert.AreEqual("Command2.Execute", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestRedo2()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();
            _manager.Undo();
            _manager.Redo();
            _manager.Redo();

            Assert.AreEqual(_command2, _manager.CurrentCommand);
            Assert.AreEqual("Command2.Execute", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestRedo3()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();
            _manager.Undo();
            _manager.Redo();
            _manager.Redo();
            _manager.Redo();

            Assert.IsNull(_manager.CurrentCommand);
            Assert.AreEqual("Command2.Execute", _receiver.ActionResultMessage);
        }

        [TestMethod()]
        public void TestReplaceUndoRedo()
        {
            _manager.Execute(_command1);
            _manager.Execute(_command2);
            _manager.Undo();
            _manager.Execute(_command3);
            _manager.Undo();
            _manager.Undo();
            _manager.Redo();
            _manager.Redo();

            Assert.AreEqual(_command3, _manager.CurrentCommand);
            Assert.AreEqual("Command3.Execute", _receiver.ActionResultMessage);
        }
    }
}
