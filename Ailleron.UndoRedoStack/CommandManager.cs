using System.Collections.Generic;

namespace Ailleron.UndoRedoStack
{
    public class CommandManager
    {
        private int _current;
        private List<ICommand> _commands;

        public int Current
        {
            get { return _current; }
        }

        public int CommandsCount
        {
            get { return _commands.Count; }
        }

        public ICommand CurrentCommand
        {
            get { return (_commands.Count > 0 && _current >= 0 && _current < _commands.Count) ? _commands[_current] : null; }
        }

        public CommandManager()
        {
            _current = -1;
            _commands = new List<ICommand>();
        }

        public void Execute(ICommand command)
        {
            command.Execute();
            _current++;
            if (_commands.Count > _current)
            {
                _commands.RemoveRange(_current, _commands.Count - _current);
            }
            _commands.Add(command);
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                if (_current >= 0)
                {
                    _commands[_current].Revert();
                    _current--;
                }
            }
        }

        public void Redo()
        {
            if (_commands.Count > 0)
            {
                if (_current < _commands.Count)
                {
                    if (_current < _commands.Count - 1)
                    {
                        _commands[_current + 1].Execute();
                    }
                    _current++;
                }
            }
        }
    }
}
