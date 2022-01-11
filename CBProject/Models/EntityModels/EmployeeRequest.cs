using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBProject.Models.EntityModels
{
    public class EmployeeRequest
    {
        public int ID { get; set; }
        public DateTime CReatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }
        public string EmployeeMessage { get; set; }
        public string CVPath { get; set; }
        public string ImagePath { get; set; }
    }
}