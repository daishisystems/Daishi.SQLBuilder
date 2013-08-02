namespace Daishi.SQLBuilder {
    public interface ICommand {
        object Result { get; }
        void Execute();
        void Undo();
    }
}