public interface ICommandVisitor
{
    void Visit(CommandMove command);
    void Visit(CommandFight command);
}
