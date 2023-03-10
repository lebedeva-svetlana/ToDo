using System.ComponentModel.DataAnnotations;

namespace ToDo.Data
{
    public class Note
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Text { get; set; }

        public bool IsDone { get; set; }

        public bool IsDeleted { get; set; }
    }
}