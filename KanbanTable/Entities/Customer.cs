namespace KanbanTable.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public int INN { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ProjectKanban> ProjectKanbans { get; set; }

    }
}

