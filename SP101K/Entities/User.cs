using System.ComponentModel.DataAnnotations;
using System;

namespace SP101K.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string clientName { get; set; }
        public DateTime dateRegistered { get; set; }
        public string Location { get; set; }
        public int NumberofUsers { get; set; }
    }
}
