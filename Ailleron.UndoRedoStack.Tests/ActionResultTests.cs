using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ailleron.UndoRedoStack.Tests
{
    [TestClass()]
    public class ActionResultTests
    {
        private IActionResult _actionResult;

        [TestInitialize()]
        public void Initialize()
        {
            _actionResult = new ActionResult();
        }

        [TestMethod()]
        public void ExecuteResultTest()
        {
            var context = new ActionContext();
            context.CommandName = "Command1";
            context.ActionType = ActionType.Execute;

            _actionResult.ExecuteResult(context);

            Assert.AreEqual("Command1.Execute", (_actionResult as ActionResult).Result);
        }
    }
}