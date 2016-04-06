
namespace Ex1_Maze
{
    public interface ICreateable<T>
    {
        GeneralMaze<T> GetMaze();
        int GetHeight();
        int GetWidth();
    }
}