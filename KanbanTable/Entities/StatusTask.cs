namespace KanbanTable.Entities
{
    public class StatusTask
    {
        public int Id { get; set; }
        public string Name { get; set; }   
       
        public StatusTask()
        {
            Name = "none";
        }
        public ICollection<TaskKanban>? TaskKanbans { get; set; }

    }
}
