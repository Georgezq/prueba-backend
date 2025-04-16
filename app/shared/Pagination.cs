namespace Prueba.Shared
{
    public class PageList<T> 
    {
        public List<T> Data { get; set; } = new();
        public int TotalCount { get; set; }
    }
}