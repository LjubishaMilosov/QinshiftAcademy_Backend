using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotesAppDA.Domain.Enums;

namespace NotesAppDA.Domain
{
    [Table("Notes")]
    public class Note
    {
        [Key] // primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
        // Navigation property
        [ForeignKey("UserId")]  // part 1 from the 1 -> many relationship with Note, where UserId is the foreign key
        public User User { get; set; }
        [Required]
        public PriorityEnum Priority { get; set; }
        [Required]
        public TagEnum Tag { get; set;  }

        [NotMapped] // states that the property will be mapped in the table , but not in the database
        public int NoteCount { get; set; }
    }
}
