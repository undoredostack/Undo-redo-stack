# Undo-redo-stack

In the editors we use daily, for text, graphics, sound and so on, we are happy to have functionality to Undo and Redo mistakes we make.

There is a certain logic to how the undo-redo system works. You know it by heart surely, but just to get you started TDD'ing. "Command" is anything that manipulates our document in the editor, eg. adding or deleting some text.
If we add command 1 and then command 2, we can undo 2 (but not undo 1, nor redo anything). Then we can undo 1 or redo 2 (but not carry out any other undo/redo). If we undo 1, then we can only redo 1, and then we can redo 2
If we add command 1, then command 2, then undo 2, then add command 3, we can undo 3. When we undo 3, we can then redo 3 or undo 1. When we undo 1, we can redo 1. If we redo 1, we can then undo 1 or redo 3.
