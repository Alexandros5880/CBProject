using System;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.EntityModels
{
    public class ContactMessage
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime UploatedDate { get; set; }
    }
}