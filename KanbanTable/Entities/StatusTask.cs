namespace KanbanTable.Entities
{
    public class StatusTask
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public ICollection<TaskKanban>? TaskKanbans { get; set; }

    }
}
