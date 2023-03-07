using ToDo.Data;

namespace ToDo.Models
{
    public class NotesViewModel
    {
        public NotesViewModel()
        {
        }

        public NotesViewModel(List<Note> notes) : this()
        {
            Notes = notes;
        }

        public Note ActiveNote { get; set; } = new();
        public List<Note> Notes { get; set; }
    }
}